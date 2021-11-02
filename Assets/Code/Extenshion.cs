using UnityEngine;

namespace Max.Asteroid
{
    public static class Extenshion
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            if (gameObject.GetComponent<T>() == null) gameObject.AddComponent<T>();
            return gameObject.GetComponent<T>();
        }

    }
}
