using UnityEngine;

namespace simpleproject.Tank.Body.Rotation
{
    public class BodyRotation : MonoBehaviour
    {
      /*  [SerializeField] private int _rotationUp;
        [SerializeField] private int _rotationDown;
        [SerializeField] private int _rotationLeft;
        [SerializeField] private int _rotationRight;*/
        [SerializeField] private Transform _bodyTransform;
        [SerializeField] private float _rotationSpeed;
        //[SerializeField] private int _rotateNow;

        public void Rotate(float ToLeft)
        {
            ToLeft *= _rotationSpeed;
            ToLeft *= Time.deltaTime;

            Debug.Log("ToLeft -> ");
            Debug.Log(ToLeft);

            Quaternion NewRotation = new Quaternion(_bodyTransform.rotation.x,
                                                    _bodyTransform.rotation.y,
                                                    _bodyTransform.rotation.z + ToLeft,
                                                    _bodyTransform.rotation.w);

            _bodyTransform.rotation = Quaternion.Lerp(_bodyTransform.rotation,
                                                      NewRotation,
                                                      1.0f);
        }
    }
}
