using System.Collections.Generic;
using UnityEngine;
using simpleproject.Managers.Transition;
using simpleproject.Pools.Loads;

namespace simpleproject.Managers.Pools.Loads

{
    public class LoadsPoolManager : MonoBehaviour
    {
        [SerializeField] private int _countGunTypes;
        [SerializeField] private int[] _poolSize;
        [SerializeField] private bool[] _canExpand;
        [SerializeField] private GameObject[] _prefabs;
        [SerializeField] protected TransitionManager _transitionManager;

        private readonly List<Queue<GameObject>> _freeLoads = new List<Queue<GameObject>>();
        private readonly Queue<GameObject> _emptyStack = new Queue<GameObject>();

        public void AddFreeLoad(int Id, GameObject Load)
        {
            _freeLoads[Id].Enqueue(Load);
        }

        private void Awake()
        {

            for (int id = 0; id < _countGunTypes; id++)
            {
                _freeLoads.Add(_emptyStack);

                for (int loadId = 0; loadId < _poolSize[id]; loadId++)
                {
                    GameObject load = Instantiate(_prefabs[id], this.transform);

                    load.SetActive(false);

                    _freeLoads[id].Enqueue(load);
                }
            }
        }

        public void Shot(int Id, Transform _towerTranform)
        {
            PoolableObject Load;

            if (_freeLoads[Id].Count > 0)
                Load = _freeLoads[Id].Dequeue().GetComponent<PoolableObject>();
            else
                if (_canExpand[Id])
                    Load = Instantiate(_prefabs[Id], this.transform).GetComponent<PoolableObject>();
                else
                    return;

            Load.Use(_towerTranform);
        }
    }
}
