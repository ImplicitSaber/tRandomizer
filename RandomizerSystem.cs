using Terraria.ModLoader;
using Terraria;
using System;
using Terraria.ID;

namespace tRandomizer
{
	public class RandomizerSystem : ModSystem
	{

        private static readonly Random rand = new Random(Guid.NewGuid().GetHashCode());

        public override void PostAddRecipes()
		{
			Config cfg = ModContent.GetInstance<Config>();
			if (cfg.RandomizeRecipeResults)
			{
				for (int i = 0; i < Recipe.numRecipes; i++)
				{
					Recipe r = Main.recipe[i];
					Random rand = new Random(Guid.NewGuid().GetHashCode());
					if((r.HasResult(ItemID.MechanicalEye) || r.HasResult(ItemID.MechanicalWorm) || r.HasResult(ItemID.MechanicalSkull)) && cfg.DontRandomizeReqdItems)
                    {
						continue;
                    }
					int id = rand.Next(1, Main.item.Length);
                    r.ReplaceResult(id, rand.Next(1, (cfg.RespectMaxStack ? ItemMaxStackGetter.GetItemMaxStack(id) : Item.CommonMaxStack) + 1));
				}
			}
		}

    }

}
