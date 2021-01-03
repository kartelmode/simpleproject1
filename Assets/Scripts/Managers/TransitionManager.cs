using UnityEngine;

namespace simpleproject.Managers.Transition
{
    public class TransitionManager : MonoBehaviour
    {
        private float FromDegreedsToRadian(float alpha)
        {
            return alpha * Mathf.PI / 180.0f;
        }

        private bool ToTheRightOfCenter(float alpha)
        {
            return (alpha > Mathf.PI);
        }

        public void ForceTransition(Transform t, Rigidbody2D rb, float speed, float direction)
        {
            direction *= speed;
            direction *= Time.fixedDeltaTime;

            float alpha = FromDegreedsToRadian(t.eulerAngles.z);

            if (ToTheRightOfCenter(alpha))
                alpha = alpha - 2.0f * Mathf.PI;

            rb.AddForce(new Vector2(-direction * Mathf.Sin(alpha),
                                     direction * Mathf.Cos(alpha)));
        }
    }
}