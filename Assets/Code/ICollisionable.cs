
using UnityEngine;

namespace Max.Asteroid
{
    public interface ICollisionable
    {
        void OnCollisionEnter2D(Collision2D collision);
    }
}
