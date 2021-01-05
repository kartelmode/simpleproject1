using UnityEngine;
using simpleproject.Tank.Transition;
using simpleproject.Tank.Body.Rotation;
using simpleproject.Managers.Pools.Loads;
using simpleproject.Tank.Parameters;

namespace simpleproject.Managers.Clicks
{
    public class ClickManager : MonoBehaviour
    {
        [SerializeField] private TankTransition _tankTransition;
        [SerializeField] private Transform _towerTransform;
        [SerializeField] private BodyRotation _bodyRotation;
        [SerializeField] private LoadsPoolManager _poolManager;
        [SerializeField] private TankParameters _tankParameters;

        private void CheckRotationAndTransition()
        {
            float ToLeft = Input.GetAxis("Horizontal");
            float ToUp = Input.GetAxis("Vertical");

            _tankTransition.Transit(ToUp);

            _bodyRotation.Rotate(ToLeft);
        }

        private void CheckShot()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _poolManager.Shot(_tankParameters.TypeOfGun, _towerTransform);
        }

        private void Update()
        {
            CheckShot();
            CheckRotationAndTransition();
        }
    }
}
