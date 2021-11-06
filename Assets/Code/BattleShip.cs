using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Max.Asteroid
{
    public class BattleShip : IShip, IMove, IRocketFire,IAcceleration
    {
        private readonly IMove _moveImplementation;
        private readonly float _shootForce;
        private readonly Transform _transform;

        public BattleShip(IMove moveImplementation, float shootForce, Transform transform)
        {
            _moveImplementation = moveImplementation;
            _shootForce = shootForce;
            _transform = transform;
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

        public void Shoot(Rigidbody2D rigidbody2D, float force)
        {
            var temAmmunition = Object.Instantiate(rigidbody2D, _transform.position, _transform.rotation);
            temAmmunition.AddForce(_transform.up * force);
        }
    }
}
