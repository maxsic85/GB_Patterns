

using UnityEngine;

namespace Max.Asteroid
{
    public class KeybordInput : IInput
    {
        PlayerData _playerData;
        IShip _ship;
        private Camera _camera;
        public KeybordInput(PlayerData data)
        {
            _camera = Camera.main;
            _playerData = data;
        }
        public void GetInput()
        {
            if (_ship == null) _ship = GameObject.FindObjectOfType<Player>()._ship;

            var deltaTime = Time.deltaTime;
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_camera.transform.position);

            if (_ship is IMove movingShip)
                movingShip.Move(Input.GetAxis("Horizontal"),
                                Input.GetAxis("Vertical"),
                                deltaTime);

            if (_ship is IRotation rot)
                rot.Rotation(direction);

            if (Input.GetButtonDown("Fire1"))
            {
                if (_ship is IRocketFire rocket) 
                rocket.Shoot(_playerData.Force);
            }

            if (_ship is IAcceleration accselShip)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    accselShip.AddAcceleration();
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    accselShip.RemoveAcceleration();
                }
            }
        }
    }
}
