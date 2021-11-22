using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Max.Asteroid
{
    public abstract class Enemy : MonoBehaviour, IMove
    {
        public Transform startPosition;
        public static AmmunitionPool _ammunitionPool;
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

        public static EnemyShip CreateEnemyShip(Health health, float speed,AmmunitionPool ammunitionPool)
        {
            var enemy = Instantiate(Resources.Load<EnemyShip>("Prefabs/Enemy"));
            enemy.Health = health;
            enemy.Speed = speed;
            _ammunitionPool = ammunitionPool;
            return enemy;
        }
        public abstract void Move(float horizontal, float vertical, float deltaTime);
        public abstract void Start();
        
        
      
    }
}
