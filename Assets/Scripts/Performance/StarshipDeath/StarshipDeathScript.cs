using Performance.StartGameManager;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Performance.StarshipDeath
{
    public class StarshipDeathScript : MonoBehaviour
    {
        public event Action GameOver;
        [SerializeField] private LayerMask layerMask;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (layerMask == (layerMask | (1 << collision.gameObject.layer)))
            {
                GameOver?.Invoke();
                Debug.Log("trigger death");
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (layerMask == (layerMask | (1 << collision.gameObject.layer)))
            {
                GameOver?.Invoke();
                Debug.Log("collision death");
            }
        }
    }
}