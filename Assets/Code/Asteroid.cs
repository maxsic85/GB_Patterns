
using System;
using UnityEngine;

namespace Max.Asteroid
{
    [Serializable]
    public sealed class Asteroid:Enemy
    {
     
        public override void Start()
        {
            transform.position = startPosition.position;
            MoveEnemy = new MoveTransform(gameObject.transform, Speed);
         
          
        }
        public override void  Move(float horizontal, float vertical, float deltaTime)
        {
            MoveEnemy?.Move(horizontal, vertical, deltaTime);
        }
    }
}
