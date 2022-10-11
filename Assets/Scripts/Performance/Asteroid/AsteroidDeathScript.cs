using Assets.Scripts.Logic.Asteroid;
using Assets.Scripts.Logic.Spawner;
using Assets.Scripts.Performance.Death;
using Assets.Scripts.Performance.Movement;
using Performance.Score;
using UnityEngine;

namespace Assets.Scripts.Performance.Asteroid
{
    public class AsteroidDeathScript : DeathScript
    {
        [SerializeField] private float speedAsteroid;

        [SerializeField] private int deathPoint;

        [SerializeField] private EAsteroidStatus asteroidStatus;
        [SerializeField] private GameObject smallAsteroidPrefab;

        private AsteroidDeath asteroidDeath;

        private void Awake()
        {
            asteroidDeath = new AsteroidDeath(transform, speedAsteroid, deathPoint);
        }

        private void SpawnSmallAsteroid()
        {
            AsteroidSpawnInfo spawnInfo = asteroidDeath.Death();
            ScoreScript.Instance.AddPoint(deathPoint);

            GameObject creatingAsteroid = Instantiate(smallAsteroidPrefab, spawnInfo.SpawnPoint, Quaternion.identity);
            creatingAsteroid.GetComponent<RectilinearMovementScript>().Init(spawnInfo.MovementDirection);
        }

        public override void Death()
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
    }
}