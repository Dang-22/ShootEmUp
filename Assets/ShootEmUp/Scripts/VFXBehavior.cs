using System;
using UnityEngine;

namespace ShootEmUp
{
    public class VFXBehavior : MonoBehaviour
    {
        #region Fields

        [SerializeField] private ParticleSystem _particleSystem;
        

        #endregion
        #region Unity Methods

        private void Update()
        {
            if (_particleSystem != null)
            {
                if (_particleSystem.isStopped)
                {
                    VFXPool.Instance.ReleaseVFX(gameObject);
                }
            }
        }

        #endregion
    }
}