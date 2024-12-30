using UnityEngine;
using UnityEngine.Splines;
using Utilities;

namespace ShootEmUp
{
    /// <summary>
    /// Enemy builder - Enemy's properties setting
    /// </summary>
    public class EnemyBuilder
    {
        #region Fields
        private GameObject _enemyPrefab;
        private SplineContainer _splineContainer;
        private GameObject _weaponPrefab;
        private float _speed;
        #endregion
        #region Public Methods
        /// <summary>
        /// Set the enemy builder base prefab
        /// </summary>
        /// <param name="prefab"></param>
        /// <returns></returns>
        public EnemyBuilder SetBasePrefab(GameObject prefab)
        {
            _enemyPrefab = prefab;  
            return this;
        }
        /// <summary>
        /// Set the enemy builder spline container
        /// </summary>
        /// <param name="spline"></param>
        /// <returns></returns>
        public EnemyBuilder SetSpline(SplineContainer spline)
        {
            _splineContainer = spline;
            return this;
        }
        /// <summary>
        /// Set the enemy weapon builder
        /// </summary>
        /// <param name="prefab"></param>
        /// <returns></returns>
        public EnemyBuilder SetWeaponBuilder(GameObject prefab){
            _weaponPrefab = prefab;
            return this;
        }
        /// <summary>
        /// Set the enemy builder speed
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        public EnemyBuilder SetSpeed(float speed)
        {
            _speed = speed;
            return this;
        }
        /// <summary>
        /// Building enemy game object
        /// </summary>
        /// <returns>Enemy game object with properties had been set</returns>
        public GameObject Build()
        {
            GameObject instance = GameObject.Instantiate(_enemyPrefab);
            SplineAnimate splineAnimate = instance.GetOrAdd<SplineAnimate>();
            splineAnimate.Container = _splineContainer;
            splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            splineAnimate.ObjectUpAxis = SplineComponent.AlignAxis.ZAxis;
            splineAnimate.MaxSpeed = _speed;
            instance.transform.position = _splineContainer.EvaluatePosition(0f);
            return instance;
        }

        #endregion
    }
}