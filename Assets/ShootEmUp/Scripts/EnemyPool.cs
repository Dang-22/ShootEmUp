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
    public class EnemyPool : MonoBehaviour
    {
        #region Fields

        [SerializeField] private List<EnemyType> _enemiesTypes;
        [SerializeField] private int _maxEnemies = 18;
        [SerializeField] private float _spawnInterval = 1f;
        [SerializeField] private float _offSet = 2f;
        [SerializeField] private GameObject _poolHoldder;
        private List<SplineContainer> _spline;
        private EnemyFactory _enemyFactory;
        private float _spawnTimer;
        private int _enemySpawned;
        private ObjectPool<GameObject> _enemyPool;  
        public EnemyPool Instance { get; private set; }
        #endregion
        #region Unity Methods

        /// <summary>
        /// 
        /// </summary>
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            //Get the component 
            _enemyFactory = new EnemyFactory();
            _spline = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
            _enemyPool = new ObjectPool<GameObject>(SpawnEnemy, OnPullOutOfPool, OnPutBackInPool, defaultCapacity: 200);
        }
        private void Update()
        {
            Spawner();
            FollowCamera();
        }

        #endregion
        #region Private Methods

        private void OnPullOutOfPool(GameObject obj)
        {
            obj.SetActive(true);
        }
        private void OnPutBackInPool(GameObject obj)
        {
            obj.gameObject.SetActive(false);
        }
        /// <summary>
        /// Follow the camera to sync spline 
        /// </summary>
        private void FollowCamera()
        {
            float cameraPositionY = Camera.main.transform.position.y;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, cameraPositionY - _offSet, gameObject.transform.position.z);
        }
        //Spawn the enemy based on time and quantities
        private void Spawner()
        {
            _spawnTimer += Time.deltaTime;
            if (_enemySpawned < _maxEnemies && _spawnTimer >= _spawnInterval)
            {
                GameObject _poolHoldderItem = GetFromPool();
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
        #endregion

        #region Public Methods

        public void ReturnToPool(GameObject obj)
        {
            _enemyPool.Release(obj);
        }

        public GameObject GetFromPool()
        {
            return _enemyPool.Get();
        }
        #endregion
    }
}