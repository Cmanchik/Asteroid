using System.Collections;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Performance.Border
{
    /// <summary>
    /// Класс уничтожающие выбранные объекты, если они выходят за колладер зоны
    /// </summary>
    public class DeadzoneScript : MonoBehaviour
    {
        /// <summary>
        /// Объекты подлижащие уничтожению
        /// </summary>
        [SerializeField] private LayerMask layerMask;

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (layerMask == (layerMask | (1 << collision.gameObject.layer)))
            {
                Destroy(collision.gameObject);
            }
        }

    }
}