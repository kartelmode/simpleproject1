using UnityEngine;
using simpleproject.Tank.Transition;
using simpleproject.Tank.Body.Rotation;
using simpleproject.MainCamera.Transition;

namespace simpleproject.Clicks.Checking
{
    public class ClickChecking : MonoBehaviour
    {
        [SerializeField] private TankTransition _tankTransition;
        [SerializeField] private BodyRotation _bodyRotation;
        [SerializeField] private CameraTransition _cameraTransition;

        private void Update()
        {
            float ToLeft = Input.GetAxis("Horizontal");
            float ToUp = Input.GetAxis("Vertical");

            _tankTransition.Transit(ToLeft, ToUp);
            _cameraTransition.Transit(ToLeft, ToUp);

            _bodyRotation.Rotate(ToLeft);
        }
    }
}
