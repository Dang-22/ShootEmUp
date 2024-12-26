using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Pool;

namespace ShootEmUp
{
    public class ProjecttilePool : MonoBehaviour
    {
        public static ProjecttilePool Instance { get; private set; }
        [SerializeField] private GameObject _projectilePrefab;
        private ObjectPool<GameObject> _enemyProjectilePool;
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

        public void Release(GameObject obj)
        {
            _enemyProjectilePool.Release(obj);
        }
        public GameObject GetProjectile()
        {
            return _enemyProjectilePool.Get();
        }
    }
}