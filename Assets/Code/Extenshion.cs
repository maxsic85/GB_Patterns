using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Max.Asteroid
{
    public static class Extenshion
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            if (gameObject.GetComponent<T>() == null) gameObject.AddComponent<T>();
            return gameObject.GetComponent<T>();
        }
        public static Vector3 GetCustomTransform(this Transform transform)
        {

            var x = Random.Range(-Screen.width / 2, Screen.width / 2);
            transform.localPosition = new Vector3(x, Screen.height, 0);
            return transform.position;
        }

        public static class CustomResources
        {
            public static T Load<T>(string path) where T : Object
            {
                return (T)Resources.Load(path, typeof(T));
            }
        }
    }
        public static partial class ObjectExtensions
        {
            public static T DeepCopy<T>(this T self)
            {
                if (!typeof(T).IsSerializable)
                {
                    Debug.Log("Type must be iserializable");
                }
                if (ReferenceEquals(self, null))
                {
                    return default;
                }

                var formatter = new BinaryFormatter();
                using (var stream = new MemoryStream())
                {
                    formatter.Serialize(stream, self);
                    stream.Seek(0, SeekOrigin.Begin);
                    return (T)formatter.Deserialize(stream);
                }
            }
        }   
}
