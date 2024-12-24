using UnityEngine;
using UnityEngine.Splines;

namespace ShootEmUp
{
    /// <summary>
    /// Call builder to making enemy
    /// </summary>
    public class EnemyFactory
    {
        /// <summary>
        /// Create, set component's value of the enemy object
        /// </summary>
        /// <param name="enemyType"></param>
        /// <param name="spline"></param>
        /// <returns></returns>
        public GameObject CreateEnemy(EnemyType enemyType, SplineContainer spline)
        {
            EnemyBuilder builder = new EnemyBuilder()
                .SetBasePrefab(enemyType.EnemyPrefabs)
                .SetSpline(spline)
                .SetSpeed(enemyType.Speed);
            return builder.Build();
        }
    }
}