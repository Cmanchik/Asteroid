using Assets.Scripts.Utils;
using UnityEngine;

namespace Performance
{
    public class ScoreScript : Singleton<ScoreScript>
    {
        private int score;
        public int Score => score;

        public void Reset()
        {
            score = 0;
        }

        public void AddPoint(int point)
        {
            score += point;
        }
    }
}