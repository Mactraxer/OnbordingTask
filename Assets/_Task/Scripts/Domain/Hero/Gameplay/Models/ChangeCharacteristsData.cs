using System;
using Domain.Hero.Gameplay.Model;

namespace Domain.Hero.Gameplay.Data
{
    [Serializable]
    public class UpgradeConfig
    {
        public ECharacteristicType Type;
        public int Level;
    }
}