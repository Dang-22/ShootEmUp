using System;
using UnityEngine;

namespace ShootEmUp
{
    /// <summary>
    /// Enemy Weapon system based on logic at strategy
    /// </summary>
    public class EnemyWeapon : Weapon
    {
        private float _fireTimer;

        private void Update()
        {
            //Auto fire after _fireTimer time
            _fireTimer += Time.deltaTime;
            if (_fireTimer >= _weaponStrategy.FireRate)
            {
                _weaponStrategy.Fire(_firePoint, _layer);
                _fireTimer = 0f;
            }
        }
    }
}