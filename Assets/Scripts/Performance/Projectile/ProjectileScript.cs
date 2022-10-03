using Assets.Scripts.Performance.Asteroid;
using UnityEngine;

namespace Assets.Scripts.Performance.Projectile
{
    public class ProjectileScript : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private bool selfDestruct;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (layerMask == (layerMask | (1 << collision.gameObject.layer)))
            {
                collision.GetComponent<AsteroidDeathScript>().Death();

                if (selfDestruct) Destroy(gameObject);
            }
        }
    }
}