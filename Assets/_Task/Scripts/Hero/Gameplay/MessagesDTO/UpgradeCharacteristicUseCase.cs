using System;
using Hero.Gameplay.Model;
using MessagePipe;

public class UpgradeCharacteristicUseCase : IDisposable
{
    private readonly HeroModel _heroModel;
    private readonly ISubscriber<UpgradeCharacteristicDTO> _subscriber;
    private readonly IDisposable _disposable;

    public UpgradeCharacteristicUseCase(HeroModel heroModel, ISubscriber<UpgradeCharacteristicDTO> subscriber)
    {
        _heroModel = heroModel;
        _subscriber = subscriber;

        var bag = DisposableBag.CreateBuilder();
        _subscriber.Subscribe(UpgradeCharacteristicMessageHandler).AddTo(bag);

        _disposable = bag.Build();
    }

    private void UpgradeCharacteristicMessageHandler(UpgradeCharacteristicDTO messageData)
    {
        _heroModel.IncreaseCharacteristic(messageData.CharacteristicType, messageData.AmountChange);
    }

    public void Dispose()
    {
        _disposable.Dispose();
    }
}
