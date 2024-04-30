using Celestial.Buffs.Debuffs;
using Celestial.Items.Materials;
using Celestial.Projectiles.Weapon;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace Celestial.Items.Weapons.Melee.Spears
{
    public class ColaxGemspear : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SkipsInitialUseSound[Item.type] = true;
            ItemID.Sets.Spears[Item.type] = true;
        }
        public override void SetDefaults()
        {
            Item.damage = 3;
            Item.DamageType = DamageClass.Melee;
            Item.width = 42;
            Item.height = 42;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 4;
            Item.value = 00000005;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.rare = 1;
            Item.UseSound = SoundID.Item1;
            Item.shootSpeed = 2.5f;
            Item.shoot = ModContent.ProjectileType<ColaxSpearProjectile>();
        }

        public override bool? UseItem(Player player)
        {
            if (!Main.dedServ && Item.UseSound.HasValue)
            {
                SoundEngine.PlaySound(Item.UseSound.Value, player.Center);
            }

            return null;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var line = new TooltipLine(Mod, "Verbose:Remove", "placeholder");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "[i:280]|Low damage, high speed Weapon")
            {
                OverrideColor = new Color(209, 208, 35)
            };
            tooltips.Add(line);

            tooltips.RemoveAll(l => l.Name.EndsWith(":Remove"));
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ColaxCrystal>(), 7);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}