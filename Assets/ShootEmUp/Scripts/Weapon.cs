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
        [SerializeField] protected WeaponStrategy _weaponStrategy;
        [SerializeField] protected Transform _firePoint;
        [SerializeField, Layer] protected int _layer;

        private void OnValidate()
        {
            _layer = gameObject.layer;
        }

        private void Start()
        {
            _weaponStrategy.Initialize();
        }

        public void SetWeaponStrategy(WeaponStrategy strategy)
        {
            _weaponStrategy = strategy;
            _weaponStrategy.Initialize();
        }
    }
}