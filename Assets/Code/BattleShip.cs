using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Max.Asteroid
{
    public class BattleShip : IShip, IMove, IRocketFire,IAcceleration,IRotation
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotateImplementation;
        private readonly float _shootForce;
        private readonly Transform _transform;
        private AmmunitionPool _ammunitionPool;

        public BattleShip(IMove moveImplementation,IRotation rotateImplementation, float shootForce, Transform transform,AmmunitionPool ammunitionPool)
        {
            _moveImplementation = moveImplementation;
            _rotateImplementation = rotateImplementation;
            _shootForce = shootForce;
            _transform = transform;
            _ammunitionPool = ammunitionPool;
        }

        public float Speed => throw new System.NotImplementedException();

        public int Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public float Damage => _shootForce;


        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        }
        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }

        public void Shoot( float force)
        {
            var ammunition = _ammunitionPool.GetAmmunition(AmmunitionType.Bullet);
            ammunition.AddForce(_transform.position, Quaternion.Euler(ammunition.transform.eulerAngles.x,
                        ammunition.transform.eulerAngles.y, _transform.eulerAngles.z), _transform.up * force);
        }

        public void Rotation(Vector3 direction)
        {
            _rotateImplementation.Rotation(direction);
        }
    }
}
