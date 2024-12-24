using System;
using System.Collections.Generic;
using UnityEngine;
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
        [SerializeField] private float _spawnInterval = 2f;
        private EnemyPool _enemyPool;
        private List<SplineContainer> _spline;
        private EnemyFactory _enemyFactory;
        private float _spawnTimer;
        private int _enemySpawned;
        /// <summary>
        /// 
        /// </summary>
        private void OnValidate()
        {
            //Get the component 
            _spline = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
        }
        private void Start()
        {
            _enemyPool = gameObject.AddComponent<EnemyPool>();
        }

        private void Update()
        {
            //Spawn the enemy based on time and quantities
            _spawnTimer += Time.deltaTime;
            if (_enemySpawned < _maxEnemies && _spawnTimer >= _spawnInterval)
            {
                SpawnEnemy();
                _spawnTimer = 0f;
            }
        }
        /// <summary>
        /// Create the enemy with factory setting
        /// </summary>
        private void SpawnEnemy()
        {
            EnemyType enemyType = _enemiesTypes[Random.Range(0, _enemiesTypes.Count)];
            SplineContainer spline = _spline[Random.Range(0, _spline.Count)];
            _enemyPool.GetEnemy(enemyType, spline);
            _enemySpawned++;
        }
    }
}