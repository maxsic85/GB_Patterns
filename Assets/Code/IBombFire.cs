using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Max.Asteroid
{
    public interface IBombFire : IWeapon
    {
        void Shoot(Rigidbody2D rigidbody2D, float force,float burstRadius);
    }
}
