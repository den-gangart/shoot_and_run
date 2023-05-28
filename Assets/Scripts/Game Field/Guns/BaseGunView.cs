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

        protected bool _isShooting = false;
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
                _isShooting = false;
                return;
            }

            if (_lastFxTime.AddSeconds(_minFXTime) < DateTime.Now)
            {
                SetFXParams();
            }
        }

        private void UpdateFX()
        {
            if (_isShooting)
            {
                _lastFxTime = DateTime.Now;
                SetFXParams();
            }
        }

        protected virtual void SetFXParams()
        {
            _fxObject.SetActive(_isShooting);
        }
    }
}
 