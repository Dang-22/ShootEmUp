using UnityEngine;

namespace Utilities
{
    public static class GameObjectExtensions
    {
        public static T GetOrAdd<T>(this GameObject go) where T : Component
        {
            T component = go.GetComponent<T>();
            return component == null ? go.AddComponent<T>() : component;
        } 
    }
}