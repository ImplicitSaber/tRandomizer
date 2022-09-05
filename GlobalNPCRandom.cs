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

		public override void ModifyNPCLoot(NPC npc, NPCLoot loot)
		{
			if (ModContent.GetInstance<Config>().randomizeMobDrops)
			{
				List<IItemDropRule> rules = loot.Get(true);
				foreach (IItemDropRule rule in rules)
				{
					if (rule == null) continue;
					loot.Remove(rule);
				}
				Random rand = new Random(Guid.NewGuid().GetHashCode());
				int amountOfDrops = rand.Next(1, 11);
				for (int i = 0; i < amountOfDrops; i++)
				{
					int id = rand.Next(1, Main.item.Length);
					int dropAmountMin = rand.Next(1, 1000);
					int dropAmountMax = rand.Next(dropAmountMin, 1000);
					loot.Add(ItemDropRule.Common(id, 1, dropAmountMin, dropAmountMax));
				}
				if (ModContent.GetInstance<Config>().dontRandomizeProgressionReqdItems)
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
						loot.Add(ItemDropRule.Common(ItemID.JungleKey, 1, 1, 1));
					}
				}
			}
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			base.SetupShop(type, shop, ref nextSlot);
			if (ModContent.GetInstance<Config>().randomizeNPCShops)
			{
				Random rand = new Random(Guid.NewGuid().GetHashCode());
				for (int i = 0; i < shop.item.Length; i++)
				{
					Config cfg = ModContent.GetInstance<Config>();
					int id = rand.Next(1, Main.item.Length);
					bool useDefMedals = rand.Next(1, 3) > 1;
					bool lowPrice = rand.Next(1, 3) > 1;
					int defMedalVal = rand.Next(1, ReadIntMaxToRandomWithMax(cfg.maxRandomDefMedals, 999));
					int platinumVal = rand.Next(0, ReadIntMaxToRandomWithMax(cfg.maxRandomPlatinum, 999));
					int goldVal = rand.Next(0, ReadIntMaxToRandomWithMax(cfg.maxRandomGold, 99));
					int silverVal = rand.Next(0, ReadIntMaxToRandomWithMax(cfg.maxRandomSilver, 99));
					int copperVal = rand.Next(1, ReadIntMaxToRandomWithMax(cfg.maxRandomCopper, 99));
					shop.item[i].SetDefaults(id);
					if (useDefMedals)
					{
						shop.item[i].shopSpecialCurrency = CustomCurrencyID.DefenderMedals;
						shop.item[i].shopCustomPrice = defMedalVal;
					}
					else
					{
						shop.item[i].shopCustomPrice = Item.buyPrice(lowPrice ? 0 : platinumVal, lowPrice ? 0 : goldVal, silverVal, copperVal);
					}

				}
			}
		}

		public override void SetDefaults(NPC npc)
		{
			base.SetDefaults(npc);
			if (npc.boss)
			{
				Random rand = new Random(Guid.NewGuid().GetHashCode());
				Config cfg = ModContent.GetInstance<Config>();
				if (cfg.randomizeBossHealth && cfg.minRandomBossHealth > cfg.maxRandomBossHealth)
				{
					npc.lifeMax = rand.Next(ReadIntMinToRandom(cfg.minRandomBossHealth), ReadIntMaxToRandom(cfg.maxRandomBossHealth));
					npc.life = npc.lifeMax;
				}
				if (cfg.randomizeBossDamage && cfg.minRandomBossDamage > cfg.maxRandomBossDamage)
				{
					npc.damage = rand.Next(ReadIntMinToRandom(cfg.minRandomBossDamage), ReadIntMaxToRandom(cfg.maxRandomBossDamage));
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
