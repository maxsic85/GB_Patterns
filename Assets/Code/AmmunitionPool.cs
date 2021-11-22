using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using static Max.Asteroid.Extenshion;

namespace Max.Asteroid
{
    public class AmmunitionPool : IAmmunitionPool<Buillet>
    {
        private readonly Dictionary<AmmunitionType, HashSet<Buillet>> _ammunitionPool;
        private readonly int _capacityPool;
        private Transform _rootPool;

        public AmmunitionPool(int capacityPool)
        {
            _ammunitionPool = new Dictionary<AmmunitionType, HashSet<Buillet>>();
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.POOL_AMMUNITION).transform;
            }

        }
        public Buillet GetAmmunition(AmmunitionType type)
        {
            Buillet result;
            switch (type)
            {
                case AmmunitionType.Bullet:
                    result = GetBullet(GetListAmmunition(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return result;
        }

        private HashSet<Buillet> GetListAmmunition(AmmunitionType type)
        {
            return _ammunitionPool.ContainsKey(type) ? _ammunitionPool[type] : _ammunitionPool[type] = new HashSet<Buillet>();
        }

        private Buillet GetBullet(HashSet<Buillet> ammunitions)
        {
            var ammunition = ammunitions.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (ammunition == null)
            {
                var laser = CustomResources.Load<Buillet>(AssetsPathAmmunition.Ammunitions[AmmunitionType.Bullet]);
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = GameObject.Instantiate(laser);
                  //  instantiate.gameObject.GetOrAddComponent<Rigidbody2D>().mass=0.1f;
                    ReturnToPool(instantiate.transform);
                    ammunitions.Add(instantiate);
                }

                GetBullet(ammunitions);
            }
            ammunition = ammunitions.FirstOrDefault(a => !a.gameObject.activeSelf);
            return ammunition;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
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
