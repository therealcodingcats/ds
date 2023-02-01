using JetBrains.Annotations;
using UnityEngine;

namespace ds
{
    public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        [CanBeNull] private static T _instance;

        [CanBeNull]
        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;

                var allObjectsWithType = FindObjectsOfType<T>();
                if (allObjectsWithType.Length == 0) return null;

                _instance = allObjectsWithType[0];

                return _instance;
            }
        }
    }
}