using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using static Max.Asteroid.Extenshion;
namespace Max.Asteroid
{
   public class TransformPool
    {
        
        private readonly Dictionary<TransformForInitType, HashSet<Transform>> _transformForInitEnemy;
        private readonly int _capacityPool;
        private Transform _rootPool;
        private readonly GameData _data;
        public TransformPool(int capacityPool, GameData gameData)
        {
            _data = gameData;
            _transformForInitEnemy = new Dictionary<TransformForInitType, HashSet<Transform>>();
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.POOL_TRANSFORM_ENEMY).transform;
            }
        }
        public Transform GetTransform(TransformForInitType type)
        {
            Transform result;
            switch (type)
            {
                case TransformForInitType.ASTEROID:
                    result = GetPosition(GetListAmmunition(type));
                    break;
                case TransformForInitType.ENEMY:
                    result = GetPosition(GetListAmmunition(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return result;
        }

        private HashSet<Transform> GetListAmmunition(TransformForInitType type)
        {
            return _transformForInitEnemy.ContainsKey(type) ? _transformForInitEnemy[type] : _transformForInitEnemy[type] = new HashSet<Transform>();
        }

        private Transform GetPosition(HashSet<Transform> transformPos)
        {
            var ammunition = transformPos.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (ammunition == null)
            {
                var transform = CustomResources.Load<Transform>(AssetsPathTransform.Transforms[TransformForInitType.ASTEROID]);
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = GameObject.Instantiate(transform);
                    instantiate.transform.position = _data.EnemyStartpositions[i].position;
                    ReturnToPool(instantiate.transform);
                    transformPos.Add(instantiate);
                }

                GetPosition(transformPos);
            }
            ammunition = transformPos.FirstOrDefault(a => !a.gameObject.activeSelf);
            return ammunition;
        }

        private void ReturnToPool(Transform transform)
        {
           // transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        public void RemovePool()
        {
            UnityEngine.Object.Destroy(_rootPool.gameObject);
        }
    }
}
