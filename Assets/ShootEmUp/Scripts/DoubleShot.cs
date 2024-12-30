using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(fileName = "DoubleShot", menuName = "ShootEmUp/WeaponStrategy/DoubleShot", order = 1)]
    public class DoubleShot : WeaponStrategy
    {
        #region Fieds

        [SerializeField] private float _spreadAngle = 15f;
        private List<GameObject> _projectiles = new List<GameObject>();

        #endregion
        #region Public Methods
        public override void Fire(Transform firePoint, LayerMask layer)
        {
            SpawnProjectile(firePoint, layer, -_spreadAngle);
            SpawnProjectile(firePoint, layer, _spreadAngle);
        }
        #endregion
    }
}