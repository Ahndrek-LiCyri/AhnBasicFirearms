using AhnBasicFirearms.Items.Crafting;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AhnBasicFirearms.Items.Weapons.Ranged.Guns
{
    class MachinePistol : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Machine Pistol");
            Tooltip.SetDefault("'No more tired trigger finger!'");
        }

        public override void SetDefaults()
        {
            item.ranged = true; // Is this a ranged weapon?
            item.noMelee = true; // Prevents damage by a NPC touching the item.
            item.damage = 1; // Inital damage with no modifications.
            item.crit = 1; // Added to the base critical chance (4%).
            item.knockBack = 0; // Knockback of the weapon. 0 = No knockback!

            item.shoot = 10; // Initial Projectile ID.
            item.shootSpeed = 7f; // Main Velocity of the shot Ammo (if base is 10 and ammo is 3, end velocity is 13). 
            item.useAmmo = AmmoID.Bullet; // Type of Ammo to use.

            item.width = 40; // X size of the Item.
            item.height = 32; // Y size of the Item.
            item.scale = 1; // The scale of the Item.
            item.useTime = 14;
            item.useAnimation = 14; // UseAnimation and useTime SHOULD match to prevent multiple attacks in one animation unless desired.
            item.useStyle = 5; // 5 = Gun/Wand.
            item.UseSound = SoundID.Item11; // Sound made when this item is used.
            item.autoReuse = true; // Does this item auto reuse if you hold the mouse?

            item.value = Item.sellPrice(0, 0, 0, 15); // The sell price. In (Platnium, Gold, Silver, Copper).
            item.rare = 0; // 0 = Early Game
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            // Offset the bullet to the muzzle
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            // Add in some random spread
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 8); // Adjust until gun looks right!
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<MakeshiftPistolIron>());
            recipe.AddIngredient(ItemID.IronBar, 3);
            recipe.AddIngredient(ItemType<SpeedEjector>());
            recipe.AddIngredient(ItemType<MetalSpring>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemType<MakeshiftPistolLead>());
            recipe2.AddIngredient(ItemID.LeadBar, 3);
            recipe2.AddIngredient(ItemType<SpeedEjector>());
            recipe2.AddIngredient(ItemType<MetalSpring>());
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
