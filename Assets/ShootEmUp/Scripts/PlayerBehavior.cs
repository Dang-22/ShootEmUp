using UnityEngine;

namespace ShootEmUp
{
    public class PlayerBehavior : MonoBehaviour
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

        #region Private Methods

        private void HandlePlayerDeath()
        {
            Debug.LogError("Player Death");
        }

        #endregion
    }
}