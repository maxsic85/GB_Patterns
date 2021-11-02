using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Max.Asteroid
{
    public interface IMove
    {
        float Speed { get; }
        void Move(float horizontal, float vertical, float deltaTime);
    }
  
}
