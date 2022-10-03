using Assets.Scripts.Logic.Weapon;
using Assets.Scripts.Performance.Movement;
using System.Timers;
using UnityEngine;

namespace Assets.Scripts.Performance.Weapon
{
    public class MachineGunWeaponScript : AWeaponScript
    {

        private void Awake()
        {
            input = new InputSystem();

            weapon = new MachineGunWeapon(speedProjectile, attackRate, weaponPos);
            input.Starship.AttackMachineGun.performed += contex => Shoot();
        }

        protected override void Shoot()
        {
            if (weapon.CanAttacked)
            {
                ProjectileSpawnData projectileData = weapon.Shoot();
                if (projectileData == null)
                {
                    Debug.LogWarning("Попытка атаковать из machineGun, когда это не возможно");
                    return;
                }

                GameObject projectileInst = Instantiate(projectilePrefab, weaponPos.position, Quaternion.identity);

                try
                {
                    projectileInst.GetComponent<RectilinearMovementScript>().Init(projectileData.Direction);
                }
                catch (System.Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
    }
}