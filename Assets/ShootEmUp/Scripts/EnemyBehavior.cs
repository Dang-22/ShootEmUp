using UnityEngine;

namespace ShootEmUp
{
    public class EnemyBehavior : MonoBehaviour
    {
        #region Fields

        private Health _health;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            _health = gameObject.GetComponent<Health>();
        }

        #endregion

        #region Events

        private void OnEnable()
        {
            _health.OnDeath += HandleEnemyDeath;
        }
        private void OnDisable()
        {
            _health.OnDeath -= HandleEnemyDeath;
        }

        #endregion

        #region Private Methods

        private void HandleEnemyDeath()
        {
            EnemyPool.Instance.ReturnToPool(gameObject);
        }

        #endregion
    }
}