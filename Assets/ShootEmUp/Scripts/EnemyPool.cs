using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

namespace ShootEmUp
{
    /// <summary>
    /// Enemy pool this class need to declare every time needed a new pool
    /// </summary>
    public class EnemyPool : MonoBehaviour
    {
        /// <summary>
        /// Object quantities in the pool
        /// </summary>
        public int PoolSize = 20;
        private EnemyFactory _enemyFactory;
        private readonly Queue<GameObject> _enemyPool = new Queue<GameObject>();

        private void Start()
        {
            // new class to call builder
            _enemyFactory = new EnemyFactory();
        }
        /// <summary>
        /// Put all object to a pool
        /// </summary>
        /// <param name="enemyType"></param>
        /// <param name="spline"></param>
        public void InitializeEnemyPool(EnemyType enemyType, SplineContainer spline)
        {
            for (int i = 0; i < PoolSize; i++)
            {
                GameObject enemy = _enemyFactory.CreateEnemy(enemyType, spline);
                enemy.SetActive(false);
                _enemyPool.Enqueue(enemy);
            }
        }
        /// <summary>
        /// Get enemy out of the pool
        /// </summary>
        /// <param name="enemyType"></param>
        /// <param name="spline"></param>
        /// <returns></returns>
        public GameObject GetEnemy(EnemyType enemyType, SplineContainer spline)
        {
            if (_enemyPool.Count > 0)
            {
                GameObject enemy = _enemyPool.Dequeue();
                enemy.SetActive(true);
                return enemy;
            }
            else
            {
                GameObject newEnemy = _enemyFactory.CreateEnemy(enemyType, spline);
                return newEnemy;
            }
        }
        /// <summary>
        /// Put enemy back in the pool
        /// </summary>
        /// <param name="enemy"></param>
        public void ReturnEnemy(GameObject enemy)
        {
            _enemyPool.Enqueue(enemy);
            enemy.SetActive(false);
        }
    }
}