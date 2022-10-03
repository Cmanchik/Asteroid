using Assets.Scripts.Logic.Weapon;
using Assets.Scripts.Performance.Movement;
using UnityEngine;

namespace Assets.Scripts.Performance.Weapon
{
    public class LaserWeaponScript : AChargingWeaponScript
    {
        private void Awake()
        {
            input = new InputSystem();

            weapon = new LaserWeapon(maxCharges, chargingRecoveryTime, speedProjectile, attackRate, weaponPos);
            input.Starship.AttackLaser.performed += context => Shoot();
        }

        protected override void Shoot()
        {
            if (weapon.CanAttacked)
            {
                ProjectileSpawnData projectileData = weapon.Shoot();
                if (projectileData == null)
                {
                    Debug.LogWarning("Попытка атаковать из laser, когда это не возможно");
                    return;
                }

                GameObject projectileInst = Instantiate(projectilePrefab, weaponPos.position, Quaternion.Euler(projectileData.Rotation));

                try
                {
                    projectileInst.GetComponent<RectilinearMovementScript>().Init(projectileData.Direction);
                }
                catch (System.Exception e)
                {
                    Debug.Log(e);
                }
            }
        }
    }
}