using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    /// <summary>
    /// Player controller
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _smoothness = 0.1f;
        [SerializeField] private float _leanAngle = 15f;
        [SerializeField] private float _leanSpeed = 5f;
        [SerializeField] private GameObject _model;
        [Header("Camera Bound")]
        [SerializeField] private Transform _cameraFollow;
        [SerializeField] private float _minX = -8f;
        [SerializeField] private float _maxX = 8f;
        [SerializeField] private float _minY = -4f;
        [SerializeField] private float _maxY = 4f;
        private InputReader _input;
        private Vector3 _currentVerlocity;
        private Vector3 _targetPosition;

        private void Start()
        {
            _input = GetComponent<InputReader>();
        }

        private void Update()
        {
            _targetPosition += new Vector3(_input.Move.x, _input.Move.y, 0f) * (_speed * Time.deltaTime);
            // min, max player position based on camera view
            var minPlayerX = _cameraFollow.position.x + _minX;
            var maxPlayerX = _cameraFollow.position.x + _maxX;
            var minPlayerY = _cameraFollow.position.y + _minY;
            var maxPlayerY = _cameraFollow.position.y + _maxY;
            // Clamp player position to the cameraview
            _targetPosition.x = Mathf.Clamp(_targetPosition.x, minPlayerX, maxPlayerX);
            _targetPosition.y = Mathf.Clamp(_targetPosition.y, minPlayerY, maxPlayerY);
            //lerp player position to target position
            transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _currentVerlocity, _smoothness);
            //rotate player while moving left-right 
            var targetRotationAngle = -_input.Move.x * _leanAngle;
            var currentYrotation = transform.localEulerAngles.y;
            var newYrotation = Mathf.LerpAngle(currentYrotation, targetRotationAngle, _leanSpeed * Time.deltaTime);
            transform.localEulerAngles = new Vector3(0, newYrotation, 0);
        }
    }
}
