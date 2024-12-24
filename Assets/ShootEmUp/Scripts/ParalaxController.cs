using System;
using UnityEngine;

namespace ShootEmUp
{
    public class ParalaxController : MonoBehaviour
    {
        [SerializeField] private Transform[] _background;
        [SerializeField] private float _smoothing = 10f;
        [SerializeField] private float _multiplier = 15f;
        private Transform _mainCamera;
        private Vector3 _previousCameraPos;

        private void Awake()
        {
            _mainCamera = Camera.main.transform;
        }

        private void Start()
        {
            _previousCameraPos = _mainCamera.position;
        }

        private void Update()
        {
            for (int i = 0; i < _background.Length; i++)
            {
                var parallax = (_previousCameraPos.y - _mainCamera.position.y) * (i * _multiplier);
                var targetY = _background[i].position.y + parallax;
                var targetPosition = new Vector3(_background[i].position.x, targetY, _background[i].position.z);
                _background[i].position = Vector3.Lerp(_background[i].position, targetPosition, _smoothing * Time.deltaTime);
            }
            _previousCameraPos = _mainCamera.position;
        }
    }
}