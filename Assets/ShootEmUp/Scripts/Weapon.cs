using System;
using UnityEngine;
using Utilities;
namespace ShootEmUp
{
    /// <summary>
    /// Base weapon class
    /// </summary>
    public abstract class Weapon : MonoBehaviour
    {
        #region Fields

        [SerializeField] protected WeaponStrategy _weaponStrategy;
        [SerializeField] protected Transform _firePoint;
        [SerializeField, Layer] protected int _layer;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            _layer = gameObject.layer;
        }

        private void Start()
        {
            _weaponStrategy.Initialize();
        }

        #endregion

        #region Public Methods

        public void SetWeaponStrategy(WeaponStrategy strategy)
        {
            _weaponStrategy = strategy;
            _weaponStrategy.Initialize();
        }

        #endregion
    }
}