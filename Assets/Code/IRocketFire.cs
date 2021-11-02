using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Max.Asteroid
{
    public interface IRocketFire : IWeapon
    {
        void Shoot (Rigidbody2D rigidbody2D, float force);
    }
}
