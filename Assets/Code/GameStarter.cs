using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Max.Asteroid
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] InputType _inputType;
        [SerializeField] private PlayerData PlayerData;
        [SerializeField] private GameData _gameData;
        private IInput input;
        private IInitPlayer _playerFactory;
        public static Queue<Transform> transforms;
        internal List<Asteroid> _asteroidList;
        internal List<EnemyShip> _enemyShipList;
        private TransformPool _transformPool;

        private void OnEnable()
        {
            ServiceLocator.SetService<IAmmunitionPool<Buillet>>(new AmmunitionPool(10));
            ServiceLocatorMonoBehavior.GetService<GameStarter>();

            GetPositionForInitEnemy();
            //Фабричные методы
            _asteroidList = new List<Asteroid>();
            _enemyShipList = new List<EnemyShip>();
            //Абстрактная фабрика
            _playerFactory = new InitPlayerSettingFactory(PlayerData).Create();
        }


        IEnumerator Start()
        {
            //TODO SPAWN POINT
            AsteroidFabric();
            yield return new WaitForSeconds(3);
            EnemyFabric();
            yield return new WaitForSeconds(5);
            StartCoroutine(nameof(Start));
        }
        private void GetPositionForInitEnemy()
        {
            transforms = new Queue<Transform>();
            for (int i = 0; i < _gameData.EnemyStartpositions.Count; i++)
            {
                transforms.Enqueue(_gameData.EnemyStartpositions[i]);
            }
        }
        private void AsteroidFabric()
        {
            var aster = FindObjectOfType<Asteroid>();
            //TODO заменить магию на data
            if (aster == null)
            {
                var enemy = Enemy.CreateAsteroid(new Health(100.0f, 100.0f), 25f);
                enemy.startPosition = transforms.Dequeue();
                _asteroidList.Add(enemy);

            }
            else
            {
                //TODO как то внедрить прототип
               //var asteroid = _asteroidList[0].DeepCopy();
               // _asteroidList.Add(asteroid.GetComponent<Asteroid>());
               // asteroid.GetComponent<Asteroid>().startPosition = transforms.Dequeue();
            }
        }
        private void EnemyFabric()
        {
            //TODO заменить магию на data
            var enemy = Enemy.CreateEnemyShip(new Health(100.0f, 100.0f), 25);
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

        void Update()
        {
            //TODO отделить физику в фиксед
            _playerFactory.Input.GetInput();
        }

    }
}
