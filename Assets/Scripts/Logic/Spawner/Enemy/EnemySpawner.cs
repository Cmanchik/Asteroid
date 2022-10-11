using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Logic.Spawner.Enemy
{
    public class EnemySpawner
    {
        private readonly float spawnDistance;

        public EnemySpawner(float spawnDistance)
        {
            this.spawnDistance = spawnDistance;
        }

        public Vector2 CreateSpawnInfo()
        {
            return Random.insideUnitCircle.normalized * spawnDistance;
        }
    }
}