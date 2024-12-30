using System;
using UnityEngine;

namespace ShootEmUp
{
    /// <summary>
    /// Player Weapon system based on logic at strategy
    /// </summary>
    public class PlayerWeapon : WeaponBase
    {
        #region Fields

        private InputReader _input;

        #endregion
        #region Unity 

        private void Awake()
        {
            _input = GetComponent<InputReader>();
        }

        protected override void Update()
        {
            if (_input.Fire)
            {
                base.Update();
            }
        }

        #endregion
    }
}