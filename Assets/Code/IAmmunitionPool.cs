using UnityEngine;
namespace Max.Asteroid
{
    public interface IAmmunitionPool<T> where T:Component 
    {
        T GetAmmunition(AmmunitionType type);
        void RemovePool();
    }
}