using Assets.Scripts.Logic.Spawner;
using Assets.Scripts.Performance.Movement;
using UnityEngine;

namespace Assets.Scripts.Performance.Spawner
{
    public class AsteroidSpawnerScript : MonoBehaviour
    {
        [SerializeField] private float spawnDistance;
        [SerializeField] private float repeateRate;

        [Space]

        [SerializeField] private GameObject asteroidPrefab;

        private AsteroidSpawner spawner;

        private void Awake()
        {
            spawner = new AsteroidSpawner(spawnDistance);
            StartSpawn();
        }

        private void Spawn()
        {
            AsteroidSpawnInfo spawnInfo = spawner.CreateSpawnInfo();

            GameObject creatingAsteroid = Instantiate(asteroidPrefab, spawnInfo.SpawnPoint, Quaternion.identity);
            creatingAsteroid.GetComponent<RectilinearMovementScript>().Init(spawnInfo.MovementDirection);
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