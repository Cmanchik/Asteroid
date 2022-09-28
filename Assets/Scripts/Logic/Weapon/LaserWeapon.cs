using UnityEngine;

namespace Assets.Scripts.Logic.Weapon
{
    public class LaserWeapon : AChargingWeapon
    {
        public LaserWeapon(float chargeRecoveryTime, float speedProjectile, float attackRate, Transform weapon) 
            : base(chargeRecoveryTime, speedProjectile, attackRate, weapon)
        {
        }
    }
}