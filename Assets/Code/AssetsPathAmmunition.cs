using System.Collections.Generic;

namespace Max.Asteroid
{
    public sealed class AssetsPathAmmunition
    {
    

        public static readonly Dictionary<AmmunitionType, string> Ammunitions = new Dictionary<AmmunitionType, string>
        {
            {
                AmmunitionType.Bullet, "Prefabs/Rocket"
            }
        };
    
    }

    public sealed class AssetsPathTransform
    {
        
        public static readonly Dictionary<TransformForInitType, string> Transforms = new Dictionary<TransformForInitType, string>
        {
            {
                TransformForInitType.ASTEROID, "Prefabs/Transform"
            }
        };
    }

}