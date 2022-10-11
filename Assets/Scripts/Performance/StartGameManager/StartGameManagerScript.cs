using System;
using Assets.Scripts.Logic.Movement;
using Assets.Scripts.Performance.Movement;
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

        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private Button startGameButton;
        [SerializeField] private TMP_Text scoreText;

        private void Awake()
        {
            gameOverPanel.SetActive(true);
            scoreText.gameObject.SetActive(false);

            startShipObject.GetComponent<StartshipMovementScript>().enabled = false;
            
            startGameButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            startShipObject.GetComponent<StartshipMovementScript>().enabled = true;
            gameOverPanel.SetActive(false);
            scoreText.gameObject.SetActive(true);
        }

        public void GameOver()
        {
            startShipObject.transform.position = startShipPoint.transform.position;
            startShipObject.GetComponentsInChildren<Transform>()[1].rotation = Quaternion.identity;
            
            startShipObject.GetComponent<StartshipMovementScript>().enabled = false;
            gameOverPanel.SetActive(true);

            scoreText.text = $"Ваш счёт: {ScoreScript.Instance.Score}";

        }
    }
}