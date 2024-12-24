using UnityEngine;
using UnityEngine.InputSystem;

namespace ShootEmUp
{
    [RequireComponent(typeof(PlayerInput))]
    //Get user input value
    public class InputReader : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private InputAction _moveAction;
        private InputAction _fireAction;
        /// <summary>
        /// Get user movement input value 
        /// </summary>
        public Vector2 Move => _moveAction.ReadValue<Vector2>();
        public bool Fire => _fireAction.ReadValue<float>() > 0f;
        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
            _moveAction = _playerInput.actions["Move"];
            _fireAction = _playerInput.actions["Fire"];
        }
    }
}