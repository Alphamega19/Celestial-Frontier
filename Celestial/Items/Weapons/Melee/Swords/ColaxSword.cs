using Celestial.Buffs.Debuffs;
using Celestial.Items.Materials;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace Celestial.Items.Weapons.Melee.Swords
{ 
	public class ColaxSword : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 6;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 36;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.knockBack = 5;
			Item.value = 00000005;
			Item.rare = 1;
			Item.UseSound = SoundID.Item1;
		}

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
			if (Main.rand.Next(4) == 0)
			{
				target.AddBuff(ModContent.BuffType<ColaxToxin>(), 120);
			}
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
			var line = new TooltipLine(Mod, "Verbose:Remove", "placeholder");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "[i:3484]|Average Weapon")
			{
				OverrideColor = new Color(0, 255, 182)
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