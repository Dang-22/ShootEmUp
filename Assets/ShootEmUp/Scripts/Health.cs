using System;
using UnityEngine;

namespace ShootEmUp
{
    /// <summary>
    /// Health system
    /// </summary>
    public class Health : MonoBehaviour
    {
        #region Fields

        [Header("Health Attributes")]
        public int _maxHealth;
        public int _currentHealth;
        public delegate void HealthChanged(int currentHealth, int newHealth);
        public event HealthChanged OnHealthChanged;
        public delegate void Died();
        public event Died OnDeath;
        #endregion
        #region Unity Methods

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        #endregion
        #region Public Methods

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                return;
            }
            _currentHealth -= damage;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            OnHealthChanged?.Invoke(_currentHealth, _currentHealth);
            if (_currentHealth <= 0)
            {
                OnDeath?.Invoke();
            }
        }

        public void Heal(int amount)
        {
            if (amount < 0) return;
            _currentHealth += amount;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            OnHealthChanged?.Invoke(_currentHealth, _currentHealth);
        }

        #endregion
    }
}