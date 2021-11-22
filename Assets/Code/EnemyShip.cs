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
      
    
        public void Shoot(float force)
        {
            var ammunition = _ammunitionPool.GetAmmunition(AmmunitionType.Bullet);
            //TODO Flip не подходит
            ammunition.AddForce(transform.GetChild(0).position, Quaternion.Euler(ammunition.transform.eulerAngles.x,
                        ammunition.transform.eulerAngles.y, transform.eulerAngles.z), -transform.up * force);
            if (ammunition.gameObject.GetComponent<SpriteRenderer>().flipX) return;
            ammunition.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            ammunition.gameObject.GetComponent<SpriteRenderer>().flipY = true;
        }
        private void Shooting()
        {
            //TODO Target Fire
            Shoot(250);
        }

       
    }
}
