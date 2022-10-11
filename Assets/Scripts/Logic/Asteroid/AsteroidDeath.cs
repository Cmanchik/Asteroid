using Assets.Scripts.Logic.Spawner;
using System;
using Performance;
using UnityEngine;

namespace Assets.Scripts.Logic.Asteroid
{
    public class AsteroidDeath
    {
        private readonly Transform transform;
        private Vector2 direction;

        private readonly float speedAsteroid;
        private int deathPoint;

        private float RandomRadianAngleZ { get { return (float)((UnityEngine.Random.Range(0, 360) * Math.PI) / 180); } }

        public AsteroidDeath(Transform transform, float speedAsteroid, int deathPoint)
        {
            this.transform = transform;
            this.speedAsteroid = speedAsteroid;
            this.deathPoint = deathPoint;
            direction = Vector2.up;
        }

        /// <summary>
        /// Возвращает случайное направление полета 
        /// </summary>
        /// <returns>Направление полета для маленького астероида</returns>
        public AsteroidSpawnInfo Death()
        {
            ScoreScript.Instance.AddPoint(deathPoint);
            
            float radian = RandomRadianAngleZ;

            double newPosX = Math.Cos(radian) * direction.x + direction.y * Math.Sin(radian);
            double newPosY = direction.y * Math.Cos(radian) - direction.x * Math.Sin(radian);

            Vector2 currentDir = new(-(float)newPosX, (float)newPosY);

            return new AsteroidSpawnInfo()
            {
                SpawnPoint = transform.position,
                MovementDirection = currentDir * speedAsteroid
            };
        }
    }
}