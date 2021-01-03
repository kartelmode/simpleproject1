using UnityEngine;

namespace simpleproject.Tank.Parameters
{
    public class TankParameters : MonoBehaviour
    {
        [SerializeField] private int _healtpoints;
        [SerializeField] private int _typeOfGun;

        public int TypeOfGun
        {
            get
            {
                return _typeOfGun;
            }
        }
    }
}
