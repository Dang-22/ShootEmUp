using System;
using UnityEngine;

namespace ShootEmUp
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField, Tooltip("Reference to the player's transform")] 
        private Transform _player;
        [SerializeField, Tooltip("Camera movement speed in units per second")] 
        private float _speed = 2f;
        private void Start()
        {
            transform.position = new Vector3(_player.position.x, _player.position.y, transform.position.z);
        }

        private void LateUpdate()
        {
            transform.position += Vector3.up * _speed * Time.deltaTime;
        }
    }
}