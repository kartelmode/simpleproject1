using UnityEngine;

namespace simpleproject.Tank.Body.Rotation
{
    public class BodyRotation : MonoBehaviour
    {
        [SerializeField] private Transform _bodyTransform;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _smooth;

        public void Rotate(float ToLeft)
        {
            ToLeft *= _rotationSpeed;
            ToLeft *= Time.deltaTime;

            Vector3 NewRotation = new Vector3(_bodyTransform.eulerAngles.x,
                                                    _bodyTransform.eulerAngles.y,
                                                    _bodyTransform.eulerAngles.z + ToLeft);

            _bodyTransform.eulerAngles = Vector3.Lerp(_bodyTransform.eulerAngles,
                                                      NewRotation,
                                                      _smooth * Time.deltaTime);
        }
    }
}
