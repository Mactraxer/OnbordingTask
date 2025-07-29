using Domain.Hero.Gameplay.Model;

namespace Domain.Hero.Gameplay.MessagesDTO
{
    public class OnTapUpgradeCharacteristicDTO
    {
        public ECharacteristicType CharacteristicType { get; }
        public int AmountChange { get; }

        public OnTapUpgradeCharacteristicDTO(ECharacteristicType characteristicType, int amountChange)
        {
            CharacteristicType = characteristicType;
            AmountChange = amountChange;
        }
    }
}