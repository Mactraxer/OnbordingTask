using System;
using System.Collections.Generic;
using System.Linq;
using ObservableCollections;
using R3;

namespace Domain.Hero.Gameplay.Model
{
    public class HeroModel : IObservableCharacteristics
    {
        public IEnumerable<ECharacteristicType> CharacteristicsType => _characteristicModels.Select(kvp => kvp.Key);
        
        private ObservableDictionary<ECharacteristicType, CharacteristicModel> _characteristicModels;

        public HeroModel(ObservableDictionary<ECharacteristicType, CharacteristicModel> characteristics)
        {
            _characteristicModels = characteristics;
        }

        public void IncreaseCharacteristic(ECharacteristicType type, int amount)
        {
            if (!_characteristicModels.ContainsKey(type))
            {
                throw new ArgumentException($"Not found characteristic = {type} in dictionary of characteristics");
            }

            if (amount < 1)
            {
                throw new ArgumentException($"Increase amount must be greater than 0. Try increase by {amount}");
            }

            _characteristicModels[type].Level.Value += amount;
        }

        public Observable<int> CharacteristicLevel(ECharacteristicType type)
        {
            if (!_characteristicModels.ContainsKey(type))
            {
                throw new ArgumentException($"Not found characteristic = {type} in dictionary of characteristics");
            }
            
            return _characteristicModels[type].Level;
        }
    }
}