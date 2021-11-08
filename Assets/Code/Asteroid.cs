
using UnityEngine;

namespace Max.Asteroid
{
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

        private void DestroyYorself()
        {
            GameStarter.transforms.Enqueue(startPosition);
            Destroy(gameObject);
        }
    }
}
