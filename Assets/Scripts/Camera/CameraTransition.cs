using UnityEngine;

namespace simpleproject.MainCamera.Transition
{
    public class CameraTransition : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private Transform _tankTransform;
        [SerializeField] private float _speed;

        [SerializeField] private float _offsetX;
        [SerializeField] private float _offsetY;

        private bool ToTheLeftOfTank(float PositionX)
        {
            return PositionX <= 0;
        }

        private bool ToTheUpOfTank(float PositionY)
        {
            return PositionY >= 0;
        }

        private Vector3 MakePosition()
        {
            Vector3 PositionWithOffset = _tankTransform.position;
            Vector3 CameraPositionRelativelyTankPosition = _cameraTransform.position - 
                                                           _tankTransform  .position;

            CameraPositionRelativelyTankPosition.z = _cameraTransform.position.z;

            if (ToTheLeftOfTank(CameraPositionRelativelyTankPosition.x))
                PositionWithOffset.x -= ((CameraPositionRelativelyTankPosition.x < _offsetX) ? 0 : _offsetX);
            else
                PositionWithOffset.x += ((CameraPositionRelativelyTankPosition.x < _offsetX) ? 0 : _offsetX);

            if (ToTheUpOfTank(CameraPositionRelativelyTankPosition.y))
                PositionWithOffset.y += ((CameraPositionRelativelyTankPosition.y < _offsetY) ? 0 : _offsetY);
            else
                PositionWithOffset.y -= ((CameraPositionRelativelyTankPosition.y < _offsetY) ? 0 : _offsetY);

            return PositionWithOffset;
        }

        public void FollowTank()
        {
            Vector3 NewPosition = MakePosition();

            NewPosition.z = _cameraTransform.position.z;

            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position,
                                                     NewPosition,
                                                     _speed * Time.deltaTime);
        }

        private void Update()
        {
            FollowTank();
        }
    }
}
