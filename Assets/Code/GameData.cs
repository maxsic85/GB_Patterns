using System.Collections.Generic;
using UnityEngine;
namespace Max.Asteroid
{
 [CreateAssetMenu(fileName = "Game", menuName = "GameData")]
  public  class GameData:ScriptableObject
    {
        [SerializeField] private Transform _playerStartPosition;
        [SerializeField] private List<Transform> _EnemyStartpositions;

        public Transform PlayerStartPosition => _playerStartPosition;
        public List<Transform> EnemyStartpositions => _EnemyStartpositions;

    }
}
