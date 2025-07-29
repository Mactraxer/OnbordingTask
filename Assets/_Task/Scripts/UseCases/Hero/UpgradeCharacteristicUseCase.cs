using System;
using MessagePipe;
using VContainer;
using VContainer.Unity;
using Domain.Hero.Gameplay.Model;
using Domain.Hero.Gameplay.MessagesDTO;

namespace UseCases.Hero
{
    public class UpgradeCharacteristicUseCase : IDisposable, IStartable
    {
        private readonly HeroModel _heroModel;
        private readonly ISubscriber<OnTapUpgradeCharacteristicDTO> _subcriber;
        private IDisposable _disposable;

        [Inject]
        public UpgradeCharacteristicUseCase(HeroModel heroModel, ISubscriber<OnTapUpgradeCharacteristicDTO> subscriber)
        {
            _heroModel = heroModel;
            _subcriber = subscriber;
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

        public void Start()
        {
            var bag = DisposableBag.CreateBuilder();
            _subcriber.Subscribe(OnTapUpgradeCharacteristicMessageHandler).AddTo(bag);

            _disposable = bag.Build();
        }
        
        private void OnTapUpgradeCharacteristicMessageHandler(OnTapUpgradeCharacteristicDTO messageData)
        {
            _heroModel.IncreaseCharacteristic(messageData.CharacteristicType, messageData.AmountChange);
        }
    }
}
