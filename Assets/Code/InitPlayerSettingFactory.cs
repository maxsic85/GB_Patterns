using System;
using UnityEngine;

namespace Max.Asteroid
{
 public   class InitPlayerSettingFactory
    {
        private readonly InputFactory inputFactory;
        private readonly PlayerFactory playerFactory;
        private readonly PlayerData data;
        IAmmunitionPool<Buillet> _ammunitionPool;

        public InitPlayerSettingFactory(PlayerData playerData)
        {
            _ammunitionPool = ServiceLocator.Resolve<IAmmunitionPool<Buillet>>();
            this.data = playerData;
            this.playerFactory = new PlayerFactory(playerData,_ammunitionPool);
            this.inputFactory = new InputFactory(playerData);
        }
        public InitPlayer Create()
        {
        
           var newPlayer= new InitPlayer(inputFactory.GetInputFromPlayer(data.InputType),playerFactory.CreatePlayer());
          
            return newPlayer;
        }

    }
}
