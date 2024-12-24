using System;
using UnityEngine;

namespace ShootEmUp
{
    /// <summary>
    /// Player Weapon system based on logic at strategy
    /// </summary>
    public class PlayerWeapon : Weapon
    {
        private float _fireTimer;
        private InputReader _input;

        private void Awake()
        {
            _input = GetComponent<InputReader>();
        }

        private void Update()
        {
            _fireTimer += Time.deltaTime;
            if (_input.Fire && _fireTimer >= _weaponStrategy.FireRate)
            {
                _weaponStrategy.Fire(_firePoint, _layer);
                _fireTimer = 0f;
            }
        }
    }
}