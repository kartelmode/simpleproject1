using UnityEngine;

namespace simpleproject.Tank.Transition
{
    public class TankTransition : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _tankRigidBody;
        [SerializeField] private float _transitionSpeed;

        public void Transit(float ToLeft, float ToUp)
        {
            ToLeft *= _transitionSpeed; ToUp *= _transitionSpeed;
            ToLeft *= Time.deltaTime; ToUp *= Time.deltaTime;

            _tankRigidBody.AddForce(new Vector2(ToLeft, ToUp));
        }
    }
}
