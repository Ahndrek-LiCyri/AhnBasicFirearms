using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AhnBasicFirearms.Items.Crafting
{
    class MetalSpring : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Metal Spring");
            Tooltip.SetDefault("'Boing!'");
        }
        public override void SetDefaults()
        {
            item.width = 12; // X size of the Item.
            item.height = 16; // Y size of the Item.
            item.maxStack = 100; // How large can the stack be for this item.

            item.value = Item.sellPrice(0, 0, 1, 0); // The sell price. In (Platnium, Gold, Silver, Copper).
            item.rare = 0; // 0 = Early Game
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar);
            recipe.anyIronBar = true; 
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}
