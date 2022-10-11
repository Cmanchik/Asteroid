using Assets.Scripts.Logic.Spawner.Enemy;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Performance.Spawner
{
    public class EnemySpawnerScript : MonoBehaviour
    {
        [SerializeField] private float spawnDistance;
        [SerializeField] private float repeateRate;

        [Space]

        [SerializeField] private GameObject enemyPrefab;

        private EnemySpawner spawner;

        private void Awake()
        {
            spawner = new EnemySpawner(spawnDistance);
        }

        private void Spawn()
        {
            Instantiate(enemyPrefab, spawner.CreateSpawnInfo(), Quaternion.identity);
        }

        public void StartSpawn()
        {
            InvokeRepeating(nameof(Spawn), 0, repeateRate);
        }

        public void StopSpawn()
        {
            CancelInvoke();
        }
    }
}