using UnityEngine;
using UnityEngine.InputSystem;

namespace ShootEmUp
{
    [RequireComponent(typeof(PlayerInput))]
    //Get user input value
    public class InputReader : MonoBehaviour
    {
        #region Fieds

        private PlayerInput _playerInput;
        private InputAction _moveAction;
        private InputAction _fireAction;

        #endregion
        #region Propeties

        /// <summary>
        /// Get user movement input value 
        /// </summary>
        public Vector2 Move => _moveAction.ReadValue<Vector2>();
        public bool Fire => _fireAction.ReadValue<float>() > 0f;

        #endregion
        #region Unity Methods

        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
            _moveAction = _playerInput.actions["Move"];
            _fireAction = _playerInput.actions["Fire"];
        }

        #endregion
    }
}