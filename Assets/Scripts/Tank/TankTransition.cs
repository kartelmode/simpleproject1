using UnityEngine;

namespace simpleproject.Tank.Transition
{
    public class TankTransition : MonoBehaviour
    {
        [SerializeField] private Transform _bodyTransform;
        [SerializeField] private Rigidbody2D _tankRigidBody;
        [SerializeField] private float _transitionSpeed;

        private float FromDegreedsToRadian(float alpha)
        {
            return alpha * Mathf.PI / 180.0f;
        }

        private bool ToTheRightOfTank(float alpha)
        {
            return (alpha > Mathf.PI);
        }

        public void Transit(float direction)
        {
            direction *= _transitionSpeed;
            direction *= Time.deltaTime;

            float alpha = FromDegreedsToRadian(_bodyTransform.eulerAngles.z);

            if (ToTheRightOfTank(alpha))
                alpha = alpha - 2.0f * Mathf.PI;

            _tankRigidBody.AddForce(new Vector2(-direction * Mathf.Sin(alpha), 
                                                 direction * Mathf.Cos(alpha)));
        }
    }
}
