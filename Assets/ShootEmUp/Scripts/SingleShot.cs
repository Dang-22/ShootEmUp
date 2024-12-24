using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(fileName = "SingleShot", menuName = "ShootEmUp/WeaponStrategy/SingleShot", order = 0)]
    //Fire one at the time  
    public class SingleShot : WeaponStrategy
    {
        /// <summary>
        /// Set projecttile's value
        /// </summary>
        /// <param name="firePoint"></param>
        /// <param name="layer"></param>
        public override void Fire(Transform firePoint, LayerMask layer)
        {
            var projectile = Instantiate(_projectilePrefab, firePoint.position, firePoint.rotation);
            projectile.transform.SetParent(firePoint);
            projectile.layer = layer;
            var projecttileComponent = projectile.GetComponent<ProjectTile>();
            projecttileComponent.SetSpeed(_projecttileSpeed);
            Destroy(projectile, _projecttileLifetime);
        }
    }
}