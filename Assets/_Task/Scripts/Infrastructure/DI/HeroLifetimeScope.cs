using VContainer;
using VContainer.Unity;
using MessagePipe;
using System;
using Hero.Gameplay.Model;
using ObservableCollections;

namespace Infrastructure.DI
{
    public class HeroLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterMessagePipe();
            RegisterUseCases(builder);
            RegisterModels(builder);
            builder.RegisterEntryPoint<GameEntryPoint>();
        }

        private void RegisterModels(IContainerBuilder builder)
        {
            ObservableDictionary<ECharacteristicType, CharacteristicModel> characteristics = new()
            {
                [ECharacteristicType.Health] = new CharacteristicModel(1),
                [ECharacteristicType.Attack] = new CharacteristicModel(1),
            };
            
            var heroModel = new HeroModel(characteristics);
            builder.RegisterInstance(heroModel);
        }


        private static void RegisterUseCases(IContainerBuilder builder)
        {
            builder.Register<UpgradeCharacteristicUseCase>(Lifetime.Singleton);
        }

    }

}
