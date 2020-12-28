using UnityEngine;
using simpleproject.Tank.Transition;
using simpleproject.Tank.Body.Rotation;

namespace simpleproject.Clicks.Checking
{
    public class ClickChecking : MonoBehaviour
    {
        [SerializeField] private TankTransition _tankTransition;
        [SerializeField] private BodyRotation _bodyRotation;

        private void Update()
        {
            float ToLeft = Input.GetAxis("Horizontal");
            float ToUp = Input.GetAxis("Vertical");

            _tankTransition.Transit(ToLeft, ToUp);

            _bodyRotation.Rotate(ToLeft);
        }
    }
}
