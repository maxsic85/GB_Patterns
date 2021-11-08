using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Max.Asteroid
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] InputType _inputType;
        [SerializeField] private PlayerData PlayerData;
        [SerializeField] private  GameData _gameData;
        public static Queue<Transform> transforms;
        private IInput input;
        private IInitPlayer _playerFactory;
        private List<Asteroid> _asteroidList;
        private List<EnemyShip> _enemyShipList;
        private AmmunitionPool _ammunitionPool;
        private TransformPool  _transformPool;

        private void OnEnable()
        {
            _ammunitionPool = new AmmunitionPool(10);
            GetPositionForInitEnemy();
            //Фабричные методы
            _asteroidList = new List<Asteroid>();
            _enemyShipList = new List<EnemyShip>();
            //Абстрактная фабрика
            _playerFactory = new InitPlayerSettingFactory(PlayerData, _ammunitionPool).Create();
        }


        IEnumerator Start()
        {
            //TO DO SPAWN POINT
            AsteroidFabric();
            yield return new WaitForSeconds(3);
            EnemyFabric();
            yield return new WaitForSeconds(5);
            StartCoroutine(nameof(Start));
        }
        private void GetPositionForInitEnemy()
        {
            //_transformPool = new TransformPool(10,_gameData);
            transforms = new Queue<Transform>();
            for (int i = 0; i < _gameData.EnemyStartpositions.Count; i++)
            {
                transforms.Enqueue(_gameData.EnemyStartpositions[i]);
            }
        
        }
        private void AsteroidFabric()
        {
            //TO DO заменить магию на data
            var enemy = Enemy.CreateAsteroid(new Health(100.0f, 100.0f), 25f);
            enemy.startPosition = transforms.Dequeue();
            _asteroidList.Add(enemy);
        }
        private void EnemyFabric()
        { 
            //TO DO заменить магию на data
            var enemy = Enemy.CreateEnemyShip(new Health(100.0f, 100.0f), 25,_ammunitionPool);
            enemy.startPosition = transforms.Dequeue();
            _enemyShipList.Add(enemy);
        }
        private void EnemiesMove()
        {
            foreach (var asteroid in _asteroidList)
            {
                asteroid?.Move(0, -1, Time.fixedDeltaTime);
            }
            foreach (var enemy in _enemyShipList)
            {
                enemy?.Move(0, -1, Time.fixedDeltaTime);
            }
        }

         void FixedUpdate()
        {
            Debug.Log(transforms.Count);
            EnemiesMove();         
        }
        // Update is called once per frame
        void Update()
        {
            //TO DO отделить физику в фиксед
            _playerFactory.Input.GetInput();
        }
      
    }
}
