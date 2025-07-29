using System.Collections.Generic;
using R3;

namespace Domain.Hero.Gameplay.Model
{
    public interface IObservableCharacteristics
    {
        public IEnumerable<ECharacteristicType> CharacteristicsType { get; }
        public Observable<int> CharacteristicLevel(ECharacteristicType type);
    }
}