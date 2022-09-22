using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Logic.Border
{
    public class BorderTeleport
    {
        private float sizeX;
        private float sizeY;

        public BorderTeleport(float sizeX, float sizeY)
        {
            this.sizeX = sizeX / 2;
            this.sizeY = sizeY / 2;
        }

        public Vector2 Teleport(Vector2 posCollision)
        {
            if (posCollision.x <= -sizeX) return new Vector2(2 * sizeX + posCollision.x, posCollision.y);
            if (posCollision.x >= sizeX) return new Vector2(posCollision.x - (2 * sizeX), posCollision.y);
            if (posCollision.y <= -sizeY) return new Vector2(posCollision.x, 2 * sizeY + posCollision.y);
            if (posCollision.y >= sizeY) return new Vector2(posCollision.x, posCollision.y - (2 * sizeY));

            return posCollision;
        }
    }
}