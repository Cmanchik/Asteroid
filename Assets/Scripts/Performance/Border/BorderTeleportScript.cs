using Assets.Scripts.Logic.Border;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Performance.Border
{
    public class BorderTeleportScript : MonoBehaviour
    {
        BorderTeleport border;

        private void Awake()
        {
            BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
            border = new BorderTeleport(boxCollider.size.x, boxCollider.size.y);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            collision.gameObject.transform.position = border.Teleport(collision.gameObject.transform.position);
        }
    }
}