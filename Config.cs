using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace tRandomizer
{
    public class Config : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Randomization")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool RandomizeMobDrops;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool RandomizeNPCShops;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool RandomizeBossHealth;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool RandomizeBossDamage;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool DontRandomizeReqdItems;

        [DefaultValue(1000)]
        [ReloadRequired]
        public int MinRandomBossHealth;

        [DefaultValue(1000000)]
        [ReloadRequired]
        public int MaxRandomBossHealth;

        [DefaultValue(1)]
        [ReloadRequired]
        public int MinRandomBossDamage;

        [DefaultValue(500)]
        [ReloadRequired]
        public int MaxRandomBossDamage;

        [DefaultValue(50)]
        [ReloadRequired]
        public int MaxRandomPlatinum;

        [DefaultValue(99)]
        [ReloadRequired]
        public int MaxRandomGold;
        [DefaultValue(99)]
        [ReloadRequired]
        public int MaxRandomSilver;

        [DefaultValue(99)]
        [ReloadRequired]
        public int MaxRandomCopper;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool RandomizeRecipeResults;

        [DefaultValue(false)]
        [ReloadRequired]
        public bool RespectMaxStack;

    }
}
