using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Max.Asteroid
{
    [Serializable]
    public abstract class Enemy : MonoBehaviour, IMove
    {
        public Transform startPosition;

        public static IAmmunitionPool<Buillet> _ammunitionPool;
        public IMove MoveEnemy { get; set; }
        public Health Health { get; private set; }
        public float Speed { get; private set; }
        public static Asteroid CreateAsteroid(Health health, float speed)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Prefabs/Asteroid"));
            enemy.Health = health;
            enemy.Speed = speed;

            return enemy;
        }

        public static EnemyShip CreateEnemyShip(Health health, float speed)
        {
            var enemy = Instantiate(Resources.Load<EnemyShip>("Prefabs/Enemy"));
            enemy.Health = health;
            enemy.Speed = speed;
            _ammunitionPool = ServiceLocator.Resolve<IAmmunitionPool<Buillet>>(); ;
            return enemy;
        }
        public abstract void Move(float horizontal, float vertical, float deltaTime);
        public abstract void Start();

        private void OnBecameInvisible()
        {
            if (gameObject.activeSelf)
            {         
                DestroyYorself();
            }
        }

        public void OnTriggerEnter2D(Collider2D colider)
        {
            if (colider.gameObject.GetComponent<Buillet>() is IBuilet)
            {
                DestroyYorself();
            }
        }
        private void DestroyYorself()
        {
            if (gameObject.GetComponent<Enemy>() is Asteroid asteroid)
            {
                ServiceLocatorMonoBehavior.GetService<GameStarter>()._asteroidList.Remove(asteroid);
            }
            if (gameObject.GetComponent<Enemy>() is EnemyShip enemyShip)
            {
                ServiceLocatorMonoBehavior.GetService<GameStarter>()._enemyShipList.Remove(enemyShip);
            }

            GameStarter.transforms.Enqueue(startPosition);
            Destroy(gameObject);
        }
    }
}
