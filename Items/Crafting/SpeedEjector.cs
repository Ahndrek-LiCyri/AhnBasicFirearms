using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AhnBasicFirearms.Items.Crafting
{
    class SpeedEjector : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Speed Ejector");
            Tooltip.SetDefault("'Faster casing Ejector for machine guns.'");
        }
        public override void SetDefaults()
        {
            item.width = 20; // X size of the Item.
            item.height = 12; // Y size of the Item.
            item.maxStack = 100; // How large can the stack be for this item.

            item.value = Item.sellPrice(0, 0, 1, 0); // The sell price. In (Platnium, Gold, Silver, Copper).
            item.rare = 0; // 0 = Early Game
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemType<MetalSpring>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
