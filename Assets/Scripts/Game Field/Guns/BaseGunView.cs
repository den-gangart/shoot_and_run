using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Guns
{
    public class BaseGunView : MonoBehaviour, IGunView
    {
        [SerializeField] private GameObject _fxObject;
        private bool _isShooting = false;

        public void SetShoot(bool isShooting)
        {
            if(_isShooting == isShooting)
            {
                return;
            }

            _isShooting = isShooting;
            _fxObject.SetActive(isShooting);
        }
    }
}
 