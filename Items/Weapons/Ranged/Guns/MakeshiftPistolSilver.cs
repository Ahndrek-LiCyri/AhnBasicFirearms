using AhnBasicFirearms.Items.Crafting;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AhnBasicFirearms.Items.Weapons.Ranged.Guns
{
    class MakeshiftPistolSilver : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Makeshift Silver Pistol");
        }

        public override void SetDefaults()
        {
            item.ranged = true; // Is this a ranged weapon?
            item.noMelee = true; // Prevents damage by a NPC touching the item.
            item.damage = 9; // Inital damage with no modifications.
            item.crit = 0; // Added to the base critical chance (4%).
            item.knockBack = 0; // Knockback of the weapon. 0 = No knockback!

            item.shoot = 10; // Initial Projectile ID.
            item.shootSpeed = 7f; // Main Velocity of the shot Ammo (if base is 10 and ammo is 3, end velocity is 13). 
            item.useAmmo = AmmoID.Bullet; // Type of Ammo to use.

            item.width = 36; // X size of the Item.
            item.height = 22; // Y size of the Item.
            item.scale = 1; // The scale of the Item.
            item.useTime = 27;
            item.useAnimation = 27; // UseAnimation and useTime SHOULD match to prevent multiple attacks in one animation unless desired.
            item.useStyle = 5; // 5 = Gun/Wand.
            item.UseSound = SoundID.Item11; // Sound made when this item is used.
            item.autoReuse = true; // Does this item auto reuse if you hold the mouse?

            item.value = Item.sellPrice(0, 0, 8, 0); // The sell price. In (Platnium, Gold, Silver, Copper).
            item.rare = 0; // 0 = Early Game
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 5); // Adjust until gun looks right!
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilverBar, 10);
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.anyWood = true; // Allows the use of any type of wood.
            recipe.AddIngredient(ItemType<MetalSpring>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
