using System;
using ObservableCollections;

namespace Hero.Gameplay.Model
{
    public class HeroModel
    {
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

            _characteristicModels[type].Value += amount;
        }
    }

    public class CharacteristicModel
    {
        public int Value;

        public CharacteristicModel(int value)
        {
            Value = value;
        }
    }

    public enum ECharacteristicType
    {
        Health = 0,
        Attack = 1,
    }
}