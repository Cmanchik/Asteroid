using Assets.Scripts.Performance.Death;
using Performance;
using UnityEngine;

namespace Assets.Scripts.Performance.Enemy
{
    public class EnemyDeathScript : DeathScript
    {
        [SerializeField] private int deathPoint;

        public override void Death()
        {
            ScoreScript.Instance.AddPoint(deathPoint);
            Destroy(gameObject);
        }
    }
}