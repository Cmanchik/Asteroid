using UnityEngine;

namespace Assets.Scripts.Performance.Weapon
{
    public abstract class AWeaponScript : MonoBehaviour
    {
        [SerializeField] protected float speedProjectile;
        [SerializeField] protected float attackRate;

        [Space]

        [SerializeField] protected Transform weapon;
        [SerializeField] protected GameObject projectilePrefab;

        public abstract void Shoot();
    }
}