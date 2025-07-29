using System;
using UnityEngine;
using UnityEngine.UIElements;
using R3;
using ContractsInterfaces;
using Domain.Hero.Gameplay.Model;

namespace Presentation.View.Hero
{
    public class HeroView : MonoBehaviour, IHeroView
    {
        private Action<ECharacteristicType> OnUpgradeClicked;
        [SerializeField] private VisualTreeAsset _heroUpgradeTemplate;
        [SerializeField] private UIDocument _uiDocument;
        private Label _healthLabel;
        private Label _attackLabel;
        private Button _upgradeHealthButton;
        private Button _upgradeAttackButton;

        Observable<ECharacteristicType> IHeroView.OnUpgradeClicked => Observable.FromEvent<ECharacteristicType>(
            handler => OnUpgradeClicked += handler,
            handler => OnUpgradeClicked -= handler
        );

        public void UpdateCharacteristic(ECharacteristicType characteristicType, int level)
        {
            switch (characteristicType)
            {
                case ECharacteristicType.Health:
                    _healthLabel.text = level.ToString();
                    break;
                case ECharacteristicType.Attack:
                    _attackLabel.text = level.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(characteristicType), characteristicType, null);
            }
        }

        private void Awake()
        {
            var root = _uiDocument.rootVisualElement;
            _healthLabel = root.Q<Label>("ValueHealthLabel");
            _attackLabel = root.Q<Label>("ValueAttackLabel");
            _upgradeHealthButton = root.Q<Button>("UpgradeHealthButton");
            _upgradeAttackButton = root.Q<Button>("UpgradeAttackButton");


            _upgradeHealthButton.clicked += () => OnUpgradeClicked?.Invoke(ECharacteristicType.Health);
            _upgradeAttackButton.clicked += () => OnUpgradeClicked?.Invoke(ECharacteristicType.Attack);
        }

        private void OnDestroy()
        {
            _upgradeHealthButton.clicked -= () => OnUpgradeClicked?.Invoke(ECharacteristicType.Health);
            _upgradeAttackButton.clicked -= () => OnUpgradeClicked?.Invoke(ECharacteristicType.Attack);
        }
    }
}
