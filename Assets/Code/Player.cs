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
        public void OnTriggerEnter2D(Collider2D colider)
        {
            if (colider.gameObject.GetComponent<Enemy>() is Enemy || colider.gameObject.GetComponent<Buillet>() is IBuilet)
            {
                //TODO take damage
                
                Time.timeScale = 0;
                StopAllCoroutines();
                Application.Quit();
             
            }
        }

    }
}