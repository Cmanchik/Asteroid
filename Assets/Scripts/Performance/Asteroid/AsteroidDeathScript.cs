using Assets.Scripts.Logic.Asteroid;
using Assets.Scripts.Logic.Spawner;
using Assets.Scripts.Performance.Movement;
using UnityEngine;

namespace Assets.Scripts.Performance.Asteroid
{
    public class AsteroidDeathScript : MonoBehaviour
    {
        [SerializeField] private float speedAsteroid;
        [SerializeField] private EAsteroidStatus asteroidStatus;
        [SerializeField] private GameObject smallAsteroidPrefab;

        private AsteroidDeath asteroidDeath;

        private void Awake()
        {
            asteroidDeath = new AsteroidDeath(transform, speedAsteroid);
        }

        public void Death()
        {
            switch (asteroidStatus)
            {
                case EAsteroidStatus.Big:
                    SpawnSmallAsteroid();
                    SpawnSmallAsteroid();
                    break;
                case EAsteroidStatus.Small:
                    break;
            }

            Destroy(gameObject);
        }

        private void SpawnSmallAsteroid()
        {
            AsteroidSpawnInfo spawnInfo = asteroidDeath.Death();

            GameObject creatingAsteroid = Instantiate(smallAsteroidPrefab, spawnInfo.SpawnPoint, Quaternion.identity);
            creatingAsteroid.GetComponent<RectilinearMovementScript>().Init(spawnInfo.MovementDirection);
        }
    }
}