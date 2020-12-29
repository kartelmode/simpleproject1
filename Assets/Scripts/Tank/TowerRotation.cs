using UnityEngine;

namespace simpleproject.Tank.Tower.Rotation
{
    public class TowerRotation : MonoBehaviour
    {
        [SerializeField] private float _smooth;
        [SerializeField] private Transform _towerTransform;
        [SerializeField] private Transform _tankPosition;

        private bool BelowTank(float PositionY)
        {
            return (PositionY < 0.0);
        }

        private void SeeOnMouse()
        {
            double HalfCircle = 180.0;

            Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 MousePositionRelativelyTankPosition = MousePosition - _tankPosition.position;

            double alpha = (Mathf.PI / 2 - Mathf.Atan(MousePositionRelativelyTankPosition.x /
                                                      MousePositionRelativelyTankPosition.y)) *
                            HalfCircle / Mathf.PI;

            if (BelowTank(MousePositionRelativelyTankPosition.y))
                alpha += HalfCircle;

            Vector3 NewRotationTower = new Vector3(_towerTransform.eulerAngles.x,
                                                   _towerTransform.eulerAngles.y,
                                                   (float)alpha - 90.0f);

            _towerTransform.eulerAngles = NewRotationTower;
        }

        private void Update()
        {
            SeeOnMouse();
        }
    }
}
