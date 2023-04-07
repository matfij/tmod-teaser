using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Teaser.Content.Projectiles
{
    public class IceShotProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Shot");
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 9;
            Projectile.timeLeft = 500;
            Projectile.light = 0.5f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            int dust1 = Dust.NewDust(Projectile.Center, 2, 2, DustID.Snow, 1f, 1f, 0, default(Color), 1f);
            Main.dust[dust1].noGravity = true;
            Main.dust[dust1].velocity *= 0.5f;
            Main.dust[dust1].scale = Main.rand.Next(100, 150) * 0.01f;

            int dust2 = Dust.NewDust(Projectile.Center, 2, 2, DustID.Ice, 1f, 1f, 0, default(Color), 1f);
            Main.dust[dust2].noGravity = true;
            Main.dust[dust2].velocity *= 0.5f;
            Main.dust[dust2].scale = Main.rand.Next(100, 150) * 0.01f;
        }
    }
}
