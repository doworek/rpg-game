using System;
using System.Collections.Generic;
using Game.Engine.Items.BasicArmor;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class SwordFactory : ItemFactory
    {
        // produce items from Sword directory
        public Item CreateItem()
        {
            List<Item> sword = new List<Item>()
            {
                new BasicSword(),
                new AncientSword(),
                new MagicSword(),
                new GoldenSword()
            };
            return sword[Index.RNG(0, sword.Count)];
        }
        public Item CreateNonMagicItem()
        {
            //MagicSword and GoldenSword only work for magic users
            List<Item> sword = new List<Item>()
            {
                new BasicSword(),
                new AncientSword(),
            };
            return sword[Index.RNG(0, sword.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            // GoldenSword only works for physical damage dealers
            List<Item> sword = new List<Item>()
            {
               new BasicSword(),
               new AncientSword(),
               new MagicSword(),
            };
            return sword[Index.RNG(0, sword.Count)];
        }
    }
}
