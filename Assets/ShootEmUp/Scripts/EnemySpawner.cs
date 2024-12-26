using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Splines;
using Random = UnityEngine.Random;

namespace ShootEmUp
{
    /// <summary>
    /// Enemy spawner 
    /// </summary>
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<EnemyType> _enemiesTypes;
        [SerializeField] private int _maxEnemies = 18;
        [SerializeField] private float _spawnInterval = 1f;
        [SerializeField] private GameObject _poolHoldder;
        private List<SplineContainer> _spline;
        private EnemyFactory _enemyFactory;
        private float _spawnTimer;
        private int _enemySpawned;
        private ObjectPool<GameObject> _pool;  
        /// <summary>
        /// 
        /// </summary>
        private void Awake()
        {
            //Get the component 
            _enemyFactory = new EnemyFactory();
            _spline = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
            _pool = new ObjectPool<GameObject>(SpawnEnemy, null, OnPutBackInPool, defaultCapacity: 200);
        }

        private void OnPutBackInPool(GameObject obj)
        {
            obj.gameObject.SetActive(false);
        }
        private void Update()
        {
            //Spawn the enemy based on time and quantities
            _spawnTimer += Time.deltaTime;
            if (_enemySpawned < _maxEnemies && _spawnTimer >= _spawnInterval)
            {
               GameObject _poolHoldderItem = _pool.Get();
                _poolHoldderItem.transform.SetParent(_poolHoldder.transform);
                _spawnTimer = 0f;
            }
        }
        /// <summary>
        /// Create the enemy with factory setting
        /// </summary>
        private GameObject SpawnEnemy()
        {
            EnemyType enemyType = _enemiesTypes[Random.Range(0, _enemiesTypes.Count)];
            SplineContainer spline = _spline[Random.Range(0, _spline.Count)];
            GameObject enemy = _enemyFactory.CreateEnemy(enemyType, spline);
            _enemySpawned++;
            return enemy;
        }
    }
}