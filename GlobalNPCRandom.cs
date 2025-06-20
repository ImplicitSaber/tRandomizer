using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;

namespace tRandomizer
{
	public class GlobalNPCRandom : GlobalNPC
	{

		private static readonly Random rand = new Random(Guid.NewGuid().GetHashCode());
		

		public override void ModifyNPCLoot(NPC npc, NPCLoot loot)
		{
			Config cfg = ModContent.GetInstance<Config>();
            if (cfg.RandomizeMobDrops)
			{
				List<IItemDropRule> rules = loot.Get(true);
				foreach (IItemDropRule rule in rules)
				{
					if (rule == null) continue;
					loot.Remove(rule);
				}
				int amountOfDrops = rand.Next(1, 11);
				for (int i = 0; i < amountOfDrops; i++)
				{
					int id = rand.Next(1, Main.item.Length);
					int maxStackExclusive = (cfg.RespectMaxStack ? ItemMaxStackGetter.GetItemMaxStack(id) : Item.CommonMaxStack) + 1;
                    int dropAmountMin = rand.Next(1, maxStackExclusive);
					int dropAmountMax = rand.Next(dropAmountMin, maxStackExclusive);
					loot.Add(ItemDropRule.Common(id, 1, dropAmountMin, dropAmountMax));
				}
				if (cfg.DontRandomizeReqdItems)
				{
					if (npc.type == NPCID.VoodooDemon)
					{
						loot.Add(ItemDropRule.Common(ItemID.GuideVoodooDoll, 1, 1, 1));
					}
					else if (npc.type == NPCID.WallofFlesh)
					{
						loot.Add(ItemDropRule.Common(ItemID.Pwnhammer, 1, 1, 1));
					}
					else if (npc.type == NPCID.Plantera)
					{
						loot.Add(ItemDropRule.Common(ItemID.TempleKey, 1, 1, 1));
					}
				}
			}
		}

		public override void ModifyShop(NPCShop shop)
		{
			base.ModifyShop(shop);
            Config cfg = ModContent.GetInstance<Config>();
            if (cfg.RandomizeNPCShops)
			{
				List<NPCShop.Entry> nEntries = new List<NPCShop.Entry>();
				foreach(NPCShop.Entry e in shop.Entries)
				{
					e.Disable();
                    int id = rand.Next(1, Main.item.Length);
                    bool lowPrice = rand.Next(1, 3) > 1;
                    int platinumVal = rand.Next(0, ReadIntMaxToRandomWithMax(cfg.MaxRandomPlatinum, Item.CommonMaxStack));
                    int goldVal = rand.Next(0, ReadIntMaxToRandomWithMax(cfg.MaxRandomGold, 99));
                    int silverVal = rand.Next(0, ReadIntMaxToRandomWithMax(cfg.MaxRandomSilver, 99));
                    int copperVal = rand.Next(1, ReadIntMaxToRandomWithMax(cfg.MaxRandomCopper, 99));
					Condition[] conditions = [..e.Conditions];
					NPCShop.Entry nE = new NPCShop.Entry(id, conditions);
					nE.Item.stack = rand.Next(1, (cfg.RespectMaxStack ? nE.Item.maxStack : Item.CommonMaxStack) + 1);
                    nE.Item.shopCustomPrice = Item.buyPrice(lowPrice ? 0 : platinumVal, lowPrice ? 0 : goldVal, silverVal, copperVal);
					nEntries.Add(nE);
				}
				foreach(NPCShop.Entry e in nEntries)
				{
					shop.Add(e);
				}
			}
		}

        public override void SetDefaults(NPC npc)
		{
			base.SetDefaults(npc);
			if (npc.boss)
			{
				Config cfg = ModContent.GetInstance<Config>();
				if (cfg.RandomizeBossHealth && cfg.MinRandomBossHealth > cfg.MaxRandomBossHealth)
				{
					npc.lifeMax = rand.Next(ReadIntMinToRandom(cfg.MinRandomBossHealth), ReadIntMaxToRandom(cfg.MaxRandomBossHealth));
					npc.life = npc.lifeMax;
				}
				if (cfg.RandomizeBossDamage && cfg.MinRandomBossDamage > cfg.MaxRandomBossDamage)
				{
					npc.damage = rand.Next(ReadIntMinToRandom(cfg.MinRandomBossDamage), ReadIntMaxToRandom(cfg.MaxRandomBossDamage));
				}
			}
		}

		public int ReadIntMaxToRandom(int toRead)
		{
			return toRead > 0 ? toRead + 1 : 2;
		}

		public int ReadIntMinToRandom(int toRead)
		{
			return toRead > 0 ? toRead : 1;
		}

		public int ReadIntMaxToRandomWithMax(int toRead, int max)
		{
			return ReadIntMaxToRandom(toRead > max ? max : toRead);
		}

	}

}
