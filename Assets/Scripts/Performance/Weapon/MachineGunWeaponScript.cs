using Assets.Scripts.Logic.Weapon;
using Assets.Scripts.Performance.Movement;
using System.Timers;
using UnityEngine;

namespace Assets.Scripts.Performance.Weapon
{
    public class MachineGunWeaponScript : AWeaponScript
    {
        private MachineGunWeapon machineGun;

        private void Awake()
        {
            machineGun = new MachineGunWeapon(speedProjectile, attackRate, weapon);
        }

        /// <summary>
        /// Подписка на событие отката оружия
        /// </summary>
        /// <param name="handler">Метод для подписки</param>
        public void SubCooldownEndEvent(ElapsedEventHandler handler)
        {
            machineGun.SubCooldownEndEvent(handler);
        }

        /// <summary>
        /// Отподписка от событие отката оружия
        /// </summary>
        /// <param name="handler">Метод для отписки</param>
        public void UnsubCooldownEndEvent(ElapsedEventHandler handler)
        {
            machineGun.UnsubCooldownEndEvent(handler);
        }


        public override void Shoot()
        {
            if (machineGun.CanAttacked)
            {
                ProjectileSpawnData projectileData = machineGun.Shoot();
                if (projectileData == null)
                {
                    Debug.LogWarning("Попытка атаковать из machineGun, когда это не возможно");
                    return;
                }

                GameObject projectileInst = Instantiate(projectilePrefab, weapon.position, Quaternion.identity);

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