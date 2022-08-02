using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace tRandomizer
{
    public class Config : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Randomization")]
        [Label("Randomize monster and boss drops")]
        [Tooltip("Setting this to true will randomize all NPC drops. This includes monsters and bosses! If this is set to false, no randomization of drops will take place.")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool randomizeMobDrops;

        [Header("Randomization")]
        [Label("Randomize NPC shops")]
        [Tooltip("Setting this to true will randomize all NPC shops. This will randomize the items and price. If this is set to false, no randomization of shop items will take place.")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool randomizeNPCShops;

        [Header("Randomization")]
        [Label("Randomize boss HP")]
        [Tooltip("Setting this to true will randomize all bosses' health. If this is set to false, no randomization of boss HP will take place.")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool randomizeBossHealth;

        [Header("Randomization")]
        [Label("Randomize boss damage")]
        [Tooltip("Setting this to true will randomize all bosses' damage. If this is set to false, no randomization of boss damage will take place.")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool randomizeBossDamage;

        [Header("Randomization")]
        [Label("Don't randomize progression required items")]
        [Tooltip("Setting this to true will stop the randomization of items required for progression, e.g. guide voodoo doll, pwnhammer. This will not matter if Randomize monster and boss drops is false.")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool dontRandomizeProgressionReqdItems;

        [Header("Randomization")]
        [Label("Minimum random boss health")]
        [Tooltip("The minimum amount of boss health the randomizer will select.")]
        [DefaultValue(1000)]
        [ReloadRequired]
        public int minRandomBossHealth;

        [Header("Randomization")]
        [Label("Maximum random boss health")]
        [Tooltip("The maximum amount of boss health the randomizer will select.")]
        [DefaultValue(1000000)]
        [ReloadRequired]
        public int maxRandomBossHealth;

        [Header("Randomization")]
        [Label("Minimum random boss damage")]
        [Tooltip("The minimum amount of boss damage the randomizer will select.")]
        [DefaultValue(1)]
        [ReloadRequired]
        public int minRandomBossDamage;

        [Header("Randomization")]
        [Label("Maximum random boss damage")]
        [Tooltip("The maximum amount of boss damage the randomizer will select.")]
        [DefaultValue(500)]
        [ReloadRequired]
        public int maxRandomBossDamage;

        [Header("Randomization")]
        [Label("Maximum random defender medal amount")]
        [Tooltip("The maximum amount of defender medals a shop will sell an item for.")]
        [DefaultValue(999)]
        [ReloadRequired]
        public int maxRandomDefMedals;

        [Header("Randomization")]
        [Label("Maximum random platinum amount")]
        [Tooltip("The maximum amount of platinum a shop will sell an item for.")]
        [DefaultValue(50)]
        [ReloadRequired]
        public int maxRandomPlatinum;

        [Header("Randomization")]
        [Label("Maximum random gold amount")]
        [Tooltip("The maximum amount of gold a shop will sell an item for.")]
        [DefaultValue(99)]
        [ReloadRequired]
        public int maxRandomGold;

        [Header("Randomization")]
        [Label("Maximum random silver amount")]
        [Tooltip("The maximum amount of silver a shop will sell an item for.")]
        [DefaultValue(99)]
        [ReloadRequired]
        public int maxRandomSilver;

        [Header("Randomization")]
        [Label("Maximum random copper amount")]
        [Tooltip("The maximum amount of copper a shop will sell an item for.")]
        [DefaultValue(99)]
        [ReloadRequired]
        public int maxRandomCopper;

    }
}
