using System;
using System.Collections.Generic;


namespace Max.Asteroid
{
    public class Health : IHealth
    {
        public float MaxHp { get; }
        public float CurrentHP { get; private set; }
        public Health(float maxHp, float currentHP)
        {
            MaxHp = maxHp;
            CurrentHP = currentHP;
        }
        public void ChangeHp(float health)
        {
            CurrentHP -= health;
        }
    }
}
