using Assets.Scripts.Logic.Spawner;
using System;
using UnityEngine;

namespace Assets.Scripts.Logic.Asteroid
{
    public class AsteroidDeath
    {
        private readonly Transform transform;
        private Vector2 direction;

        private float RandomRadianAngleZ { get { return (float)((UnityEngine.Random.Range(0, 360) * Math.PI) / 180); } }

        public AsteroidDeath(Transform transform)
        {
            this.transform = transform;
            direction = Vector2.up;
        }

        /// <summary>
        /// Возвращает случайное направление полета 
        /// </summary>
        /// <returns>Направление полета для маленького астероида</returns>
        public AsteroidSpawnInfo Death()
        {
            float radian = RandomRadianAngleZ;

            double newPosX = Math.Cos(radian) * direction.x + direction.y * Math.Sin(radian);
            double newPosY = direction.y * Math.Cos(radian) - direction.x * Math.Sin(radian);

            Vector2 currentDir = new(-(float)newPosX, (float)newPosY);

            return new AsteroidSpawnInfo()
            {
                SpawnPoint = transform.position,
                MovementDirection = currentDir
            };
        }
    }
}