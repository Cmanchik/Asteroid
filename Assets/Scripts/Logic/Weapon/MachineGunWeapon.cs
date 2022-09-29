using System;
using System.Timers;
using UnityEngine;

namespace Assets.Scripts.Logic.Weapon
{
    public class MachineGunWeapon : AWeapon
    {
        /// <summary>
        /// Перевод из градусов в радианы угла Z
        /// </summary>
        protected float RadianAngleZ { get { return (float)((weapon.localEulerAngles.z * Math.PI) / 180); } }

        public MachineGunWeapon(float speedProjectile, float attackRate, Transform weapon) : base(speedProjectile, attackRate, weapon)
        {
        }

        /// <summary>
        /// Логика полета снаряда
        /// </summary>
        /// <returns>Возвращает направление полёта снаряда без его поворота. Если снаряд нельзя выпустить, то возвращает null</returns>
        public override ProjectileSpawnData Shoot()
        {
            if (!CanAttacked) return null;

            double newPosX = Math.Cos(RadianAngleZ) * directionProjectile.x + directionProjectile.y * Math.Sin(RadianAngleZ);
            double newPosY = directionProjectile.y * Math.Cos(RadianAngleZ) - directionProjectile.x * Math.Sin(RadianAngleZ);

            Vector2 currentDir = new(-(float)newPosX, (float)newPosY);
            Vector2 newDirProjectile = currentDir * speedProjectile;

            CanAttacked = false;

            return new ProjectileSpawnData
            {
                Direction = newDirProjectile,
                Rotation = Vector3.zero
            };
        }
    }
}