using System;
using UnityEngine;

namespace ShootEmUp
{
    public class ProjectTile : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private GameObject _muzzlePrefab;
        [SerializeField] private GameObject _hitPrefab;
        private Transform _parent;
        /// <summary>
        /// Set speed of the projecttile
        /// </summary>
        /// <param name="speed"></param>
        public void SetSpeed(float speed)
        {
            _speed = speed;
        }
        /// <summary>
        /// Set parent object 
        /// </summary>
        /// <param name="parent"></param>
        public void SetParent(Transform parent)
        {
            _parent = parent;
        }

        private void Start()
        {
            //if muzzle prefab is not null then we spawn, set parent and destroy it based on custom condition
            if (_muzzlePrefab != null)
            {
                var muzzleVFX = Instantiate(_muzzlePrefab, transform.position, Quaternion.identity);
                muzzleVFX.transform.forward = gameObject.transform.forward;
                muzzleVFX.transform.SetParent(_parent);
                DestroyParticleSystem(muzzleVFX);
            }
        }

        private void Update()
        {
            transform.SetParent(null);
            transform.position += transform.up * (_speed * Time.deltaTime);
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
                var hitVFX = Instantiate(_hitPrefab, contact.point, Quaternion.identity);
                DestroyParticleSystem(hitVFX);
            }
            Destroy(gameObject);
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
            Destroy(muzzleVFX, ps.main.duration);
        }
    }
}