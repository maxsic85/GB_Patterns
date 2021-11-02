using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Max.Asteroid
{
    public class MoveTransform : IMove
    {
        private readonly Transform _transform;
        public float Speed { get; protected set; }
        private Vector3 _move;
        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;
        }


        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            var rb = _transform.gameObject.GetOrAddComponent<Rigidbody>();
            rb.AddForce(_move * speed);
            // _transform.localPosition += _move;
        }
    }
}
