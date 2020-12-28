using UnityEngine;

namespace simpleproject.MainCamera.Transition
{
    public class CameraTransition : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private float _transitionSpeed;
        [SerializeField] private float _smooth;

        public void Transit(float ToLeft, float ToUp)
        {
            ToLeft *= _transitionSpeed; ToUp *= _transitionSpeed;
            ToLeft *= Time.deltaTime; ToUp *= Time.deltaTime;

            Vector3 NewPosition = new Vector3(_cameraTransform.position.x + ToLeft,
                                              _cameraTransform.position.y + ToUp,
                                              _cameraTransform.position.z);

            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position,
                                                     NewPosition,
                                                     _smooth * Time.deltaTime);
        }
    }
}
