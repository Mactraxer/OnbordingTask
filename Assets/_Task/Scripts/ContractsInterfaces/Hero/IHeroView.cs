using R3;
using Domain.Hero.Gameplay.Model;

namespace ContractsInterfaces
{
    public interface IHeroView
    {
        Observable<ECharacteristicType> OnUpgradeClicked { get; }
        void UpdateCharacteristic(ECharacteristicType characteristicType, int level);
    }
}
