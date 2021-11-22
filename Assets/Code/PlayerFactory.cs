using System;
using UnityEngine;

namespace Max.Asteroid
{
    public class PlayerFactory
    {
        IShip _ship;
        Camera _camera;
        PlayerData _PlayerData;
        IAmmunitionPool<Buillet> _ammunitionPool;
        public PlayerFactory(PlayerData playerData,IAmmunitionPool<Buillet> ammunitionPool)
        {
            _PlayerData = playerData;
            _camera = Camera.main;
            _ammunitionPool = ammunitionPool;
        }

        public IShip CreatePlayer()
        {
            _camera = Camera.main;
            var Player = GameObject.Instantiate(Resources.Load<Player>("Prefabs/Player"));
            var moveTransform = new AccelerationMove(Player.transform, _PlayerData.Speed, _PlayerData.Acceleration);
            var rotation = new RotationShip(Player.transform);
            _ship = new BattleShip(moveTransform,rotation, _PlayerData.Force, Player.transform,_ammunitionPool);
            var player = GameObject.FindObjectOfType<Player>();
            player._ship = _ship;
            return _ship;
        }

    }
}
