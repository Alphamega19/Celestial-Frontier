using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Celestial.Common.GlobalNPCs;

namespace Celestial.Buffs.Debuffs
{
    public class ColaxToxin : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ColaxPlayer>().ColaxToxinDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<GlobalDebuffNPC>().ColaxToxinDebuff = true;
        }
    }

    public class ColaxPlayer : ModPlayer
    {
        public bool ColaxToxinDebuff;

        public override void ResetEffects()
        {
            ColaxToxinDebuff = false;
        }

        public override void UpdateBadLifeRegen()
        {
            if (ColaxToxinDebuff)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 4;
            }
        }
    }
}