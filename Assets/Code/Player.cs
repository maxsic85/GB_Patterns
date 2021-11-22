using System;
using UnityEngine;
namespace Max.Asteroid
{
    internal sealed class Player : MonoBehaviour,IPlayer
    {
        public IShip _ship;

        [SerializeField] Rigidbody2D _velocity;

        private void Start()
        {
            _velocity = gameObject.GetComponent<Rigidbody2D>();
        }
        private void OnBecameInvisible()
        {
            if (gameObject.activeSelf)
            {
                transform.position = Vector2.down;
                _velocity.velocity = Vector2.zero;
            }
        }
        private void Update()
        {
       
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
           
        }
     
    }
}