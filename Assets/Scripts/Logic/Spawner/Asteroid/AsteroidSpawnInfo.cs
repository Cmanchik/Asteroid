using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Logic.Spawner
{
    public struct AsteroidSpawnInfo
    {
        /// <summary>
        /// Точка создания объекта
        /// </summary>
        public Vector2 SpawnPoint;

        /// <summary>
        /// Направление движения объекта
        /// </summary>
        public Vector2 MovementDirection;
    }
}