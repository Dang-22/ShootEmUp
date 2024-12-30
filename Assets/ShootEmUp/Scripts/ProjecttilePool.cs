using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Pool;

namespace ShootEmUp
{
    public class ProjecttilePool : MonoBehaviour
    {
        #region Fields

        public static ProjecttilePool Instance { get; private set; }
        [SerializeField] private GameObject _projectilePrefab;
        private ObjectPool<GameObject> _enemyProjectilePool;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            _enemyProjectilePool =
                new ObjectPool<GameObject>(ProjectileSpawn, OnPullOutOfPool, OnPutBackInPool, defaultCapacity: 100);
            
        }

        #endregion

        #region Private Methods

        private GameObject ProjectileSpawn()
        {
            GameObject projectile = Instantiate(_projectilePrefab);
            return projectile;
        }

        private void OnPullOutOfPool(GameObject obj)
        {
            obj.SetActive(true);
        }
        private void OnPutBackInPool(GameObject obj)
        {
            obj.gameObject.SetActive(false);
        }
        

        #endregion

        #region Public Methods

        public void Release(GameObject obj)
        {
            _enemyProjectilePool.Release(obj);
        }
        public GameObject GetProjectile()
        {
            return _enemyProjectilePool.Get();
        }

        #endregion
    }
}