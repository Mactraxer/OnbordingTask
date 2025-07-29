using System;
using System.Collections.Generic;
using MessagePipe;
using R3;
using VContainer.Unity;
using ContractsInterfaces;
using Domain.Hero.Gameplay.Data;
using Domain.Hero.Gameplay.Model;
using Domain.Hero.Gameplay.MessagesDTO;


namespace Presentation.Presenter.Hero
{
    public class HeroPresenter : IStartable
    {
        private readonly IHeroView _view;
        private readonly IPublisher<OnTapUpgradeCharacteristicDTO> _onTapUpgradePublisher;
        private readonly IObservableCharacteristics _observableCharacteristics;
        private readonly CompositeDisposable _disposables = new();
        private readonly List<UpgradeConfig> _heroUpgradeConfig;

        public HeroPresenter(IObservableCharacteristics observableCharacteristics, IHeroView view, IPublisher<OnTapUpgradeCharacteristicDTO> onTapUpgradePublisher, List<UpgradeConfig> heroUpgradeConfig)
        {
            _view = view;
            _onTapUpgradePublisher = onTapUpgradePublisher;
            _observableCharacteristics = observableCharacteristics;
            _heroUpgradeConfig = heroUpgradeConfig;
        }

        public void Start()
        {
            _view.OnUpgradeClicked.Subscribe(OnUpgradeClickedHandler).AddTo(_disposables);

            foreach (var characteristicType in _observableCharacteristics.CharacteristicsType)
            {
                _observableCharacteristics.CharacteristicLevel(characteristicType)
                    .Subscribe(level => _view.UpdateCharacteristic(characteristicType, level))
                    .AddTo(_disposables);
            }
        }

        private void OnUpgradeClickedHandler(ECharacteristicType type)
        {
            if (!_heroUpgradeConfig.Exists(config => config.Type == type))
            {
                throw new ArgumentException($"Upgrade configuration for characteristic {type} not found.");
            }

            var upgradeAmount = _heroUpgradeConfig.Find(config => config.Type == type).Level;
            _onTapUpgradePublisher.Publish(new OnTapUpgradeCharacteristicDTO(type, upgradeAmount));
        }
    }
}

