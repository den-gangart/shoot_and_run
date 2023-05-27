using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Guns
{
    public class BaseGunView : MonoBehaviour, IGunView
    {
        [SerializeField] private float _minFXTime;
        [SerializeField] private GameObject _fxObject;

        private bool _isShooting = false;
        private DateTime _lastFxTime = DateTime.MinValue;

        public void SetShoot(bool isShooting)
        {
            if(_isShooting == isShooting)
            {
                return;
            }

            _isShooting = isShooting;
            _lastFxTime = DateTime.Now;
            UpdateFX();
        }

        private void FixedUpdate()
        {
            if (_isShooting)
            {
                return;
            }

            bool isFxDone = _lastFxTime.AddSeconds(_minFXTime) < DateTime.Now;
            if (isFxDone)
            {
                _fxObject.SetActive(false);
            }
        }

        private void UpdateFX()
        {
            if (_isShooting)
            {
                _lastFxTime = DateTime.Now;
                _fxObject.SetActive(true);
            }
        }
    }
}
 