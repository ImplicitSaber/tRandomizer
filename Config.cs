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
        [Tooltip("Setting this to true will randomize all bosses' health. Range: 1,000 HP - 1,000,000 HP. If this is set to false, no randomization of boss HP will take place.")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool randomizeBossHealth;

        [Header("Randomization")]
        [Label("Don't randomize progression required items")]
        [Tooltip("Setting this to true will stop the randomization of items required for progression, e.g. guide voodoo doll, pwnhammer. This will not matter if Randomize monster and boss drops is false.")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool dontRandomizeProgressionReqdItems;

    }
}
