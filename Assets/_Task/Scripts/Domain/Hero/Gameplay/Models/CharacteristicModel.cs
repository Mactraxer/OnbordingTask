using R3;

namespace Domain.Hero.Gameplay.Model
{
    public class CharacteristicModel
    {
        public ReactiveProperty<int> Level = new();

        public CharacteristicModel(int value)
        {
            Level.Value = value;
        }
    }
}