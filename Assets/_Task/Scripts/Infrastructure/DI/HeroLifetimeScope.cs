using UnityEngine;
using VContainer;
using VContainer.Unity;
using MessagePipe;
using ObservableCollections;
using Domain.Hero.Gameplay.Model;
using Domain.Hero.Gameplay.MessagesDTO;
using Infrastructure.Configs;
using Presentation.View.Hero;
using Presentation.Presenter.Hero;
using UseCases.Hero;

namespace Infrastructure.DI
{
    public class HeroLifetimeScope : LifetimeScope
    {
        [SerializeField] private HeroUpgradeCharacteristicsConfig _heroUpgradeConfig;
        [SerializeField] private HeroView _heroView;

        protected override void Configure(IContainerBuilder builder)
        {
            var options = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<OnTapUpgradeCharacteristicDTO>(options);
            builder.RegisterInstance(_heroView).AsImplementedInterfaces();
            RegisterModels(builder);
            RegisterUseCases(builder);
            builder.RegisterEntryPoint<HeroPresenter>().WithParameter(_heroUpgradeConfig.UpgradeChange);
        }

        private void RegisterModels(IContainerBuilder builder)
        {
            ObservableDictionary<ECharacteristicType, CharacteristicModel> characteristics = new()
            {
                [ECharacteristicType.Health] = new CharacteristicModel(1),
                [ECharacteristicType.Attack] = new CharacteristicModel(1),
            };

            var heroModel = new HeroModel(characteristics);
            builder.RegisterInstance(heroModel).As<HeroModel>();
            builder.RegisterInstance<IObservableCharacteristics>(heroModel);
        }

        private void RegisterUseCases(IContainerBuilder builder)
        {
            builder.Register<UpgradeCharacteristicUseCase>(Lifetime.Singleton).As<IStartable>();
        }
    }
}
