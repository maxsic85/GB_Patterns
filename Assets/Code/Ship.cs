using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Max.Asteroid
{
    public sealed class Ship : IShip,IMove,IRotation,IAcceleration
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotateImplementation;

        public Ship(IMove moveImplementation, IRotation rotateImplementation)
        {
            _moveImplementation = moveImplementation;
            _rotateImplementation = rotateImplementation;
        }

        public float Speed => _moveImplementation.Speed;

        public int Health { get ; set ; }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _rotateImplementation.Rotation(direction);
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
    }
}
