using System;
using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public class ProjectTile : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _speed;
        [SerializeField] private GameObject _muzzlePrefab;
        [SerializeField] private GameObject _hitPrefab;
        [SerializeField] private float _lifeTimeInterval = 2f;
        private float _lifeTimer;
        private bool _isReleased = false;

        #endregion
        #region Unity Methods

        private void Start()
        {
            SpawnProjectile();
        }
        private void Update()
        {
            MoveProjectile();
            ExpireProjectile();
        }

        #endregion
        #region Public Methods

        /// <summary>
        /// Set speed of the projecttile
        /// </summary>
        /// <param name="speed"></param>
        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        #endregion
        #region Private Methods

        private void SpawnProjectile()
        {
            if (_muzzlePrefab != null)
            {
                _muzzlePrefab.transform.forward = gameObject.transform.forward;
                gameObject.transform.SetParent(ProjecttilePool.Instance.transform);
            }
        }


        private void MoveProjectile()
        {
            transform.position += transform.up * (_speed * Time.deltaTime);
        }

        private void ExpireProjectile()
        {
            _lifeTimer += Time.deltaTime;
            if (_lifeTimer >= 1)
            {
                ProjecttilePool.Instance.Release(gameObject);
                _lifeTimer = 0;
            }
        }
        

        #endregion
        #region Events

        /// <summary>
        /// If hit on collision we spawn effect and destroy the game object
        /// </summary>
        /// <param name="other"></param>
        private void OnCollisionEnter(Collision other)
        {
            if (_isReleased)
            {
                return;
            }
            if (_hitPrefab != null)
            {
                ContactPoint contact = other.contacts[0];
                var hitVFX = VFXPool.Instance.GetVFX(gameObject.transform);
                var ps = hitVFX.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    ps.Play();
                }
            }
            _isReleased = true;
            ProjecttilePool.Instance.Release(gameObject);
        }

        private void OnEnable()
        {
            _isReleased = false;
        }

        #endregion
    }
}