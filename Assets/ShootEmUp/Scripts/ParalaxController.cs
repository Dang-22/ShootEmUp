using System;
using UnityEngine;

namespace ShootEmUp
{
    /// <summary>
    /// Run 
    /// </summary>
    public class ParalaxController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Transform[] _background;
        [SerializeField] private float _smoothing = 10f;
        [SerializeField] private float _multiplier = 15f;
        [SerializeField] private float _speed = 1f;
        private Transform _mainCamera;
        private Vector3 _defaultBackgroundPosition;
        

        #endregion
        #region Unity Methods
        private void Awake()
        {
            _defaultBackgroundPosition = transform.position;
        }

        private void Update()
        {
            if (transform.position.y <= 0)
            {
                transform.position = new Vector3(transform.position.x, _defaultBackgroundPosition.y, transform.position.z);
                
            }
        }

        private void LateUpdate()
        {
            transform.position -= Vector3.up * _speed * Time.deltaTime;
        }

        #endregion
    }
}