using Assets.Scripts.Utils;
using UnityEngine;

namespace Performance
{
    public class ScoreScript : Singleton<ScoreScript>
    {
        [SerializeField] private int asteroidPoint = 10;
        
        private int score;
        public int Score => score;

        public void Reset()
        {
            score = 0;
        }

        public void AddPoint()
        {
            score += asteroidPoint;
        }
    }
}