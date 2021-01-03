using UnityEngine;
using simpleproject.Managers.Transition;

namespace simpleproject.Tank.Transition
{
    public class TankTransition : MonoBehaviour
    {
        [SerializeField] private Transform _bodyTransform;
        [SerializeField] private Rigidbody2D _tankRigidBody;
        [SerializeField] private float _transitionSpeed;
        [SerializeField] private TransitionManager _transitionManager;

        public void Transit(float direction)
        {
            _transitionManager.ForceTransition(_bodyTransform, _tankRigidBody, _transitionSpeed, direction);
        }
    }
}
