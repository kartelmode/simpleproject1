using UnityEngine;

namespace simpleproject.Pools.Loads
{
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

        public abstract void Use(Transform _towerTransform);
        protected abstract void ReturnToThePool();
    }
}
