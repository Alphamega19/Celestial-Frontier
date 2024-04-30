using Terraria;
using Terraria.ModLoader;
using Celestial.Dusts;
using Microsoft.Xna.Framework;

namespace Celestial.Common.GlobalNPCs
{
	internal class GlobalDebuffNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		public bool ColaxToxinDebuff;

		public override void ResetEffects(NPC npc)
		{
			ColaxToxinDebuff = false;
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (ColaxToxinDebuff)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 4;
			}
		}

		public override void PostAI(NPC npc)
		{
			if (ColaxToxinDebuff)
			{
				npc.velocity *= 0.5f;

				if(Main.rand.NextBool(10))
				{
                    Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<ColaxDust>());
                }
            }
		}

		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
            if (ColaxToxinDebuff)
			{
				drawColor.R = 1; 
				drawColor.G = 34;
				drawColor.B = 52;
			}

        }
	}
}