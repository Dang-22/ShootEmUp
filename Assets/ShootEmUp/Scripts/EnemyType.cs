using UnityEngine;

namespace ShootEmUp
{
    /// <summary>
    /// Make a option to create scriptable object
    /// </summary>
    [CreateAssetMenu(fileName = "EnemyType", menuName = "ShootEmUp/EnemyType", order = 0)]
    // Enemy making scriptable object
    public class EnemyType : ScriptableObject
    {
        #region Fields
        /// <summary>
        /// Enemy prefab (not required any component yet)
        /// </summary>
        [SerializeField] private GameObject enemyPrefabs;
        /// <summary>
        /// TODO
        /// </summary>
        [SerializeField] private GameObject weaponPrefab;
        /// <summary>
        /// Enemy's speed
        /// </summary>
        [SerializeField] private float speed;
        #endregion
        #region Propeties

        public GameObject EnemyPrefabs => enemyPrefabs;
        public GameObject WeaponPrefab => weaponPrefab;
        public float Speed => speed;

        #endregion
    }
}