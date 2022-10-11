using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Logic.Spawner
{
    public class AsteroidSpawner 
    {
        private readonly float spawnDistance;
        private readonly float speedAsteroid;

        public AsteroidSpawner(float spawnDistance, float speedAsteroid)
        {
            this.spawnDistance = spawnDistance;
            this.speedAsteroid = speedAsteroid;
        }

        public AsteroidSpawnInfo CreateSpawnInfo()
        {
            Vector2 spawnPoint = Random.insideUnitCircle.normalized * spawnDistance;

            float angle = Random.Range(-15, 15);
            Quaternion rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
            Vector2 direction = rotation * -spawnPoint / (speedAsteroid * 100);

            return new AsteroidSpawnInfo
            {
                MovementDirection = direction,
                SpawnPoint = spawnPoint
            };
        }
    }
}