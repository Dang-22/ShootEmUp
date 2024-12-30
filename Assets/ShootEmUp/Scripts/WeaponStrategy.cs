using System;
using UnityEngine;

namespace ShootEmUp
{
    public abstract class WeaponStrategy : ScriptableObject
    {
        #region Fields

        [SerializeField] private int _damage = 10;
        [SerializeField] private float _fireRate = 0.5f;
        [SerializeField] protected float _projecttileSpeed = 1f;
        [SerializeField] protected float _projecttileLifetime = 4f;
        [SerializeField] protected GameObject _projectilePrefab;

        #endregion

        #region Properties

        /// <summary>
        /// Damage of the projecttile
        /// </summary>
        public int Damage { get; private set; }
        /// <summary>
        /// Fire rate of the projecttile
        /// </summary>
        public float FireRate { get; private set; }

        #endregion

        /// <summary>
        /// Init Strategy
        /// </summary>

        #region Unity Methods

        private void Awake()
        {
            Damage = _damage;
            FireRate = _fireRate;
        }

        #endregion

        #region Initialization

        public virtual void Initialize()
        {
        }

        #endregion
        public abstract void Fire(Transform firePoint, LayerMask layer);
        protected void SpawnProjectile(Transform firePoint, int layer, float angleOffset)
        {
            var projectile = ProjecttilePool.Instance.GetProjectile();
            projectile.transform.position = firePoint.position;
            projectile.transform.rotation = firePoint.rotation;
            projectile.layer = layer;
            projectile.transform.Rotate(0f, angleOffset, 0f);

            var projecttileComponent = projectile.GetComponent<ProjectTile>();
            if (projecttileComponent != null)
            {
                projecttileComponent.SetSpeed(_projecttileSpeed);
            }
        }
    }
}