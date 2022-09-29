using Assets.Scripts.Logic.Weapon;
using Assets.Scripts.Performance.Movement;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Performance.Weapon
{
    public class LaserWeaponScript : AWeaponScript
    {
        [SerializeField] private float chargingRecoveryTime;

        private LaserWeapon laserWeapon;

        private void Awake()
        {
            laserWeapon = new LaserWeapon(chargingRecoveryTime, speedProjectile, attackRate, weapon);    
        }

        public override void Shoot()
        {
            if (laserWeapon.CanAttacked)
            {
                ProjectileSpawnData projectileData = laserWeapon.Shoot();
                if (projectileData == null)
                {
                    Debug.LogWarning("Попытка атаковать из laser, когда это не возможно");
                    return;
                }

                GameObject projectileInst = Instantiate(projectilePrefab, weapon.position, Quaternion.Euler(projectileData.Rotation));

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