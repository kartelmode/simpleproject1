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

        private readonly List<Stack<GameObject>> _freeLoads = new List<Stack<GameObject>>();
        private readonly Stack<GameObject> _emptyStack = new Stack<GameObject>();

        public void AddFreeLoad(int Id, GameObject Load)
        {
            _freeLoads[Id].Push(Load);
        }

        private void Awake()
        {

            for (int id = 0; id < _countGunTypes; id++)
            {
                _freeLoads.Add(_emptyStack);

                for (int loadId = 0; loadId < _poolSize[id]; loadId++)
                    _freeLoads[id].Push(Instantiate(_prefabs[id], this.transform));
            }
        }

        public void Shot(int Id, Transform _towerTranform)
        {
            PoolableObject Load;

            if (_freeLoads[Id].Count > 0)
                Load = _freeLoads[Id].Pop().GetComponent<PoolableObject>();
            else
                if (_canExpand[Id])
                    Load = Instantiate(_prefabs[Id], this.transform).GetComponent<PoolableObject>();
                else
                    return;

            Load.Use(_towerTranform);
        }
    }
}
