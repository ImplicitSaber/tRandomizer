using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace tRandomizer
{
    internal class ItemMaxStackGetter
    {

        private static int[] itemMaxStacks = new int[Main.item.Length];

        public static int GetItemMaxStack(int id)
        {
            if (itemMaxStacks[id] > 0) return itemMaxStacks[id];
            Item i = new Item(id);
            itemMaxStacks[id] = i.maxStack;
            return i.maxStack;
        }

    }
}
