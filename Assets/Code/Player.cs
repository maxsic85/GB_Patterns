using System;
using UnityEngine;
namespace Max.Asteroid
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;

        private Camera _camera;
        private IShip _ship;
        
        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(gameObject.transform, _speed, _acceleration);
            var rotation = new RotationShip(transform);
          //  _ship = new Ship(moveTransform, rotation);
           _ship = new BattleShip(moveTransform,_force,transform);
        }
        private void Update()
        {
            var deltaTime = Time.deltaTime;
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);

            if (_ship is IMove movingShip)
                movingShip.Move(Input.GetAxis("Horizontal"),
                                Input.GetAxis("Vertical"),
                                deltaTime);

            if (Input.GetButtonDown("Fire1"))
            {
                if (_ship is IRocketFire rocket)
                    rocket.Shoot(_bullet, _force);
            }

            if (_ship is IAcceleration accselShip)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    accselShip.AddAcceleration();
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    accselShip.RemoveAcceleration();
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _hp--;
            }
        }
    }
}