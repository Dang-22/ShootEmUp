using System;
using UnityEngine;

namespace ShootEmUp
{
    public class ProjectTile : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private GameObject _muzzlePrefab;
        [SerializeField] private GameObject _hitPrefab;
        [SerializeField] private float _lifeTimeInterval = 2f;
        private float _lifeTimer;
        /// <summary>
        /// Set speed of the projecttile
        /// </summary>
        /// <param name="speed"></param>
        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        private void Start()
        {
            SpawnProjectile();
        }

        public void SpawnProjectile()
        {
            if (_muzzlePrefab != null)
            {
                _muzzlePrefab.transform.forward = gameObject.transform.forward;
                gameObject.transform.SetParent(ProjecttilePool.Instance.transform);
            }
        }

        private void Update()
        {
            transform.position += transform.up * (_speed * Time.deltaTime);
            ExpireProjectile();
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

        /// <summary>
        /// If hit on collision we spawn effect and destroy the game object
        /// </summary>
        /// <param name="other"></param>
        private void OnCollisionEnter(Collision other)
        {
            if (_hitPrefab != null)
            {
                ContactPoint contact = other.contacts[0];
                var hitVFX = VFXPool.Instance.GetVFX(gameObject.transform);
                var ps = hitVFX.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    ps = hitVFX.GetComponentInChildren<ParticleSystem>();
                    ps.Play();
                }
                if (!ps.isPlaying)
                {
                    VFXPool.Instance.ReleaseVFX(hitVFX);
                }
            }
            ProjecttilePool.Instance.Release(gameObject);
            
        }
        /// <summary>
        /// Destroy muzzle VFX at the end of effect
        /// </summary>
        /// <param name="muzzleVFX"></param>
        private void DestroyParticleSystem(GameObject muzzleVFX)
        {
            var ps = muzzleVFX.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps = muzzleVFX.GetComponentInChildren<ParticleSystem>();
            }

            if (ps.main.duration <= 0)
            {
                VFXPool.Instance.ReleaseVFX(muzzleVFX);
            }
        }
    }
}