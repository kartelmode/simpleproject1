using UnityEngine;

namespace simpleproject.Pools.Loads
{
    [ExecuteAlways]
    public abstract class PoolableObject : MonoBehaviour
    {
        [SerializeField] private int _hideDeltaTime;

        private void OnEnable()
        {
            Invoke("Hide", _hideDeltaTime);
        }
        private void Hide()
        {
            this.gameObject.SetActive(false);
            ReturnToThePool();
        }

        public abstract void Use(Transform _towerTranform);
        protected abstract void ReturnToThePool();
    }
}
