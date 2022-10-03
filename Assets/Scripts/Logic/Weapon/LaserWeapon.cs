using UnityEngine;

namespace Assets.Scripts.Logic.Weapon
{
    public class LaserWeapon : AChargingWeapon
    {
        public LaserWeapon(int maxCharges, float chargeRecoveryTime, float speedProjectile, float attackRate, Transform weapon) : 
            base(maxCharges, chargeRecoveryTime, speedProjectile, attackRate, weapon)
        {
        }

        public override ProjectileSpawnData Shoot()
        {
            if (!CanAttacked) return null;

            if (NumberCharges == MaxCharges)
            {
                timerChargeRecovery.Start();
            }

            NumberCharges--;

            canAttacked = false;
            OnShootedInvoke();

            return new ProjectileSpawnData
            {
                Direction = Vector2.up,
                Rotation = weapon.rotation.eulerAngles
            };
        }
    }
}