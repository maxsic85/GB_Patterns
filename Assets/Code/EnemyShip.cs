using System;
using UnityEngine;

namespace Max.Asteroid
{
    public class EnemyShip : Enemy, IRocketFire
    {
        public float Damage => throw new NotImplementedException();
        public Rigidbody2D _bullet;
        private Transform _rotPool;
      
        public override void Start()
        {
            transform.position = startPosition.position;
            MoveEnemy = new MoveTransform(gameObject.transform, Speed);
            InvokeRepeating(nameof(Shooting), 1, 5);     
        }

        public override void Move(float horizontal, float vertical, float deltaTime)
        {
            MoveEnemy?.Move(horizontal, vertical, deltaTime);
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Player>() is IPlayer || collision is IBuilet)
            {
                DestroyYorself();
            }
        }
        private void OnBecameInvisible()
        {
            if (gameObject.activeSelf)
            {
                DestroyYorself();
            }
        }
        public void Shoot(float force)
        {
            var ammunition = _ammunitionPool.GetAmmunition(AmmunitionType.Bullet);
            ammunition.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            ammunition.gameObject.GetComponent<SpriteRenderer>().flipY = true;
            ammunition.AddForce(transform.position, Quaternion.Euler(ammunition.transform.eulerAngles.x,
                        ammunition.transform.eulerAngles.y, transform.eulerAngles.z), -transform.up * force);
        }
        private void Shooting()
        {
            //TO DO Target Fire
            Shoot(250);
        }

        private void DestroyYorself()
        {
            GameStarter.transforms.Enqueue(startPosition);
            Destroy(gameObject);
        }
    }
}
