using UnityEngine;

namespace Max.Asteroid
{
    [CreateAssetMenu(fileName = "Player", menuName = "Data")]
    public class PlayerData : ScriptableObject
    {
 
        [SerializeField] InputType _inpputType;
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _force;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Vector2Int _position;
        public float Speed => _speed;
        public float Acceleration => _acceleration;
        public float Force => _force;

        public Rigidbody2D Billet => _bullet;

        public InputType InputType => _inpputType;

    }
}
