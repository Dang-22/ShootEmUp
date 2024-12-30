using UnityEngine;

namespace ShootEmUp
{
    /// <summary>
    /// Fire style
    /// </summary>
    public abstract class WeaponBase : Weapon
    {
        #region Fields

        private float _fireTimer;
        

        #endregion
        #region Unity Methods

        protected virtual void Update()
        {
            HandleFiring();
        }

        #endregion
        #region FireOneShot

        /// <summary>
        /// Auto fire after _fireTimer time
        /// </summary>
        private void HandleFiring()
        {
            _fireTimer += Time.deltaTime;

            if (_fireTimer >= _weaponStrategy.FireRate)
            {
                _weaponStrategy.Fire(_firePoint, _layer);
                _fireTimer = 0f;
            }
        }

        #endregion
    }
}