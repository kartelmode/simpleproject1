using UnityEngine;
using simpleproject.Pools.Loads;
using simpleproject.Managers.Transition;
using simpleproject.Managers.Pools.Loads;

namespace simpleproject.Tank.Loads.Bullets
{
    public class Bullet : PoolableObject
    {
        [SerializeField] private LoadsPoolManager _poolManager;
        [SerializeField] private Transform _bulletTransform;
        [SerializeField] private Transform _parent;
        [SerializeField] private Rigidbody2D _bulletRigidBody;
        [SerializeField] private TransitionManager _transitionManager;
        [SerializeField] private int _loadId;
        [SerializeField] private int _bulletSpeed;

        private void Awake()
        {
            _parent = this.transform.parent;
            Debug.Log(this.transform);
            _poolManager = GetComponentInParent<LoadsPoolManager>();
            _transitionManager = GameObject.Find("Managers").GetComponent<TransitionManager>();
        }

        private void FixedUpdate()
        {
            if (this.gameObject.activeSelf)
                _transitionManager.ForceTransition(_bulletTransform, _bulletRigidBody, _bulletSpeed, 1.0f);
        }

        public override void Use(Transform _towerTranform)
        {
            _bulletTransform.SetParent(null);
            this.gameObject.SetActive(true);

            _bulletTransform = _towerTranform;
        }

        protected override void ReturnToThePool()
        {
            _bulletTransform.SetParent(_parent);
            _poolManager.AddFreeLoad(_loadId, this.gameObject);
        }
    }
}
