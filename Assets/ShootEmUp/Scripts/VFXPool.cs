using System;
using UnityEngine;
using UnityEngine.Pool;

namespace ShootEmUp
{
    public class VFXPool : MonoBehaviour
    {
        #region Fields
        [SerializeField] private GameObject _vfxPrefab;
        private ObjectPool<GameObject> _vfxPool;
        public static VFXPool Instance { get; private set; }
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
            _vfxPool =
                new ObjectPool<GameObject>(VFXSpawn, OnPullOutOfPool, OnPutBackInPool, defaultCapacity: 100);
        }
        #endregion
        #region Private Method

        private void OnPullOutOfPool(GameObject obj)
        {
            obj.SetActive(true);
        }

        private void OnPutBackInPool(GameObject obj)
        {
            obj.SetActive(false);
        }
        private GameObject VFXSpawn()
        {
            var instance = Instantiate(_vfxPrefab);
            instance.transform.SetParent(gameObject.transform);
            return instance;
        }

        #endregion
        #region Public Method
        public GameObject GetVFX(Transform parent)
        {
            GameObject fx = _vfxPool.Get();
            fx.transform.position = parent.position;
            return fx;
        }
        public void ReleaseVFX(GameObject vfx)
        {
            _vfxPool.Release(vfx);
        }
        #endregion
    }
}