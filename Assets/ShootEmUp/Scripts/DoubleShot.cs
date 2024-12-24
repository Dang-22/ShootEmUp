using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(fileName = "DoubleShot", menuName = "ShootEmUp/WeaponStrategy/DoubleShot", order = 1)]
    public class DoubleShot : WeaponStrategy
    {
        [SerializeField] private float _spreadAngle = 15f;
        public override void Fire(Transform firePoint, LayerMask layer)
        {
            for (int i = 0; i < 2; i++)
            {
                var projectile = Instantiate(_projectilePrefab, firePoint.position, firePoint.rotation);
                projectile.transform.SetParent(firePoint);
                projectile.layer = layer;
                projectile.transform.Rotate(0f, _spreadAngle * (i - 1), 0f);
                var projecttileComponent = projectile.GetComponent<ProjectTile>();
                projecttileComponent.SetSpeed(_projecttileSpeed);
                Destroy(projectile, _projecttileLifetime);
            }
        }
    }
}