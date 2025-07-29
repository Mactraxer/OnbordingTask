using System.Collections.Generic;
using UnityEngine;
using Domain.Hero.Gameplay.Data;

namespace Infrastructure.Configs
{
    [CreateAssetMenu(fileName = "HeroUpgradeCharacteristicsConfig", menuName = "Configs/HeroUpgradeCharacteristicsConfig")]
    public class HeroUpgradeCharacteristicsConfig : ScriptableObject
    {
        public List<UpgradeConfig> UpgradeChange;
    }
}