using System;
using Assets.Scripts.Logic.Movement;
using Assets.Scripts.Performance.Movement;
using Assets.Scripts.Performance.Spawner;
using Assets.Scripts.Performance.StarshipDeath;
using Assets.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Performance.StartGameManager
{
    public class StartGameManagerScript : Singleton<StartGameManagerScript>
    {
        [SerializeField] private GameObject startShipPoint;
        [SerializeField] private GameObject startShipObject;
        [SerializeField] private AsteroidSpawnerScript asteroidSpawner;

        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private Button startGameButton;
        [SerializeField] private TMP_Text scoreText;

        private void Awake()
        {
            gameOverPanel.SetActive(true);
            scoreText.gameObject.SetActive(false);
            startShipObject.GetComponent<StarshipDeathScript>().GameOver += GameOver;
            startGameButton.onClick.AddListener(StartGame);
        }

        private void Start()
        {
            startShipObject.SetActive(false);
        }

        private void StartGame()
        {
            startShipObject.SetActive(true);
            gameOverPanel.SetActive(false);
            scoreText.gameObject.SetActive(true);
            asteroidSpawner.StartSpawn();
        }

        public void GameOver()
        {
            startShipObject.SetActive(false);
            asteroidSpawner.StopSpawn();

            startShipObject.transform.position = startShipPoint.transform.position;
            startShipObject.GetComponentsInChildren<Transform>()[1].rotation = Quaternion.identity;
            
            gameOverPanel.SetActive(true);

            scoreText.text = $"Ваш счёт: {ScoreScript.Instance.Score}";
            ScoreScript.Instance.Reset();

            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

            int maxLength = bullets.Length > asteroids.Length ? bullets.Length : asteroids.Length;
            for (int i = 0; i < maxLength; i++)
            {
                if (i < bullets.Length) Destroy(bullets[i]);
                if (i < asteroids.Length) Destroy(asteroids[i]);
            }
        }
    }
}