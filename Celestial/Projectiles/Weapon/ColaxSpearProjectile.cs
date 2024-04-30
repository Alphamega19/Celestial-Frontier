using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace Celestial.Projectiles.Weapon
{
    public class ColaxSpearProjectile : ModProjectile
    {
        protected virtual float HoldoutRangeMin => 24f;
        protected virtual float HoldoutRangeMax => 80f;

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Spear);
        }

        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];
            int duration = player.itemAnimationMax;

            player.heldProj = Projectile.whoAmI;

            if(Projectile.timeLeft > duration)
            {
               Projectile.timeLeft = duration;
            }

            Projectile.velocity = Vector2.Normalize(Projectile.velocity);

            float halfDuration = duration * 0.5f;
            float progress;

            if (Projectile.timeLeft < halfDuration)
            {
                progress = Projectile.timeLeft / halfDuration;
            }
            else
            {
                progress = (duration - Projectile.timeLeft) / halfDuration;
            }

            Projectile.Center = player.MountedCenter + Vector2.SmoothStep(Projectile.velocity * HoldoutRangeMin, Projectile.velocity * HoldoutRangeMax, progress);

            if (Projectile.spriteDirection == -1)
            {
                Projectile.rotation += MathHelper.ToRadians(45f);
            }
            else
            {
                Projectile.rotation += MathHelper.ToRadians(135f);
            }

            if(!Main.dedServ)
            {

            }

            return false;
        }
    }
}
