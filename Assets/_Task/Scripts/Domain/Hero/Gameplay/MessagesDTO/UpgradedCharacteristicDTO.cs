using Domain.Hero.Gameplay.Model;

namespace Domain.Hero.Gameplay.MessagesDTO
{
    public class UpgradedCharacteristicDTO
    {
        public ECharacteristicType CharacteristicType;
        public int CurrentValue;

        public UpgradedCharacteristicDTO(ECharacteristicType characteristicType, int currentValue)
        {
            CharacteristicType = characteristicType;
            CurrentValue = currentValue;
        }
    }
}