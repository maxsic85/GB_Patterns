using UnityEngine;

namespace Max.Asteroid
{
   public class Buillet:MonoBehaviour,IBuilet
    {
        [SerializeField] private float _timeToDestruct = 10;
        [SerializeField] private float _baseDamage = 10;
        [SerializeField] private AmmunitionType _type;
        protected float _currentDamage;
        private Rigidbody2D _rigidbody2D;
        private Transform _rotPool;
        public AmmunitionType Type => _type;
        public Transform RotPool
        {
            get
            {
                if (_rotPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_AMMUNITION);
                    _rotPool = find == null ? null : find.transform;
                }

                return _rotPool;
            }
        }
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        private void OnBecameInvisible()
        {
            if (gameObject.activeSelf)
            {
                ReturnToPool();
            }
        }
        public void OnTriggerEnter2D(Collider2D colider)
        {
            ReturnToPool();
        }
        public void AddForce(Vector3 position, Quaternion rotation, Vector3 dir)
        {
            ActiveAmmunition(position, rotation);
            _rigidbody2D?.AddForce(dir);
        }
        private void ActiveAmmunition(Vector3 position, Quaternion rotation)
        {
            _currentDamage = _baseDamage;
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            Invoke(nameof(ReturnToPool), _timeToDestruct);
            transform.SetParent(null);
        }
        protected void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            CancelInvoke(nameof(ReturnToPool));
            transform.SetParent(RotPool);

            if (!RotPool)
            {
                Destroy(gameObject);
            }
        }
    }
}

