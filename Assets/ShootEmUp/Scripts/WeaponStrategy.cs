using System;
using UnityEngine;

namespace ShootEmUp
{
    public abstract class WeaponStrategy : ScriptableObject
    {
        [SerializeField] private int _damage = 10;
        [SerializeField] private float _fireRate = 0.5f;
        [SerializeField] protected float _projecttileSpeed = 5f;
        [SerializeField] protected float _projecttileLifetime = 4f;
        [SerializeField] protected GameObject _projectilePrefab;
        /// <summary>
        /// Damage of the projecttile
        /// </summary>
        public int Damage;
        /// <summary>
        /// Fire rate of the projecttile
        /// </summary>
        public float FireRate;

        /// <summary>
        /// Init Strategy
        /// </summary>
        private void OnValidate()
        {
            Damage = _damage;
            FireRate = _fireRate;
        }
        public virtual void Initialize()
        {
        }
        public abstract void Fire(Transform firePoint, LayerMask layer);
    }
}