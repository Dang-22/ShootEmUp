using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(fileName = "SingleShot", menuName = "ShootEmUp/WeaponStrategy/SingleShot", order = 0)]
    //Fire one at the time  
    public class SingleShot : WeaponStrategy
    {
        #region Public Methods

        /// <summary>
        /// Set projecttile's value
        /// </summary>
        /// <param name="firePoint"></param>
        /// <param name="layer"></param>
        public override void Fire(Transform firePoint, LayerMask layer)
        {
            SpawnProjectile(firePoint, layer, 0f);
        }

        #endregion
    }
}