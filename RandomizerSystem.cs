using Terraria.ModLoader;
using Terraria;
using System;
using Terraria.ID;
using System.Collections.Generic;
using Terraria.WorldBuilding;
using Terraria.GameContent.Generation;
using Terraria.IO;

namespace tRandomizer
{
	public class RandomizerSystem : ModSystem
	{
		public override void PostAddRecipes()
		{
			bool rrR = ModContent.GetInstance<Config>().randomizeRecipeResults;
			bool dnrPRI = ModContent.GetInstance<Config>().dontRandomizeProgressionReqdItems;
			if (rrR)
			{
				for (int i = 0; i < Recipe.numRecipes; i++)
				{
					Recipe r = Main.recipe[i];
					Random rand = new Random(Guid.NewGuid().GetHashCode());
					if((r.HasResult(ItemID.MechanicalEye) || r.HasResult(ItemID.MechanicalWorm) || r.HasResult(ItemID.MechanicalSkull)) && dnrPRI)
                    {
						continue;
                    }
					r.ReplaceResult(rand.Next(1, Main.item.Length), rand.Next(1, 1000));
				}
			}
		}

    }

}
