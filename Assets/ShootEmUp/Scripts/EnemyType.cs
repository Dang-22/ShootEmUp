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
        /// <summary>
        /// Enemy prefab (not required any component yet)
        /// </summary>
        public GameObject EnemyPrefabs;
        /// <summary>
        /// TODO
        /// </summary>
        public GameObject WeaponPrefab;
        /// <summary>
        /// Enemy's speed
        /// </summary>
        public float Speed;
    }
}