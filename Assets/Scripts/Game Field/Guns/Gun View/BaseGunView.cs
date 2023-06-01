using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Guns
{
    public class BaseGunView : MonoBehaviour, IGunView
    {
        [SerializeField] private float _minFXTime;

        private bool _isShooting = false;
        private DateTime _lastShootTime = DateTime.MinValue;

        public void Shoot()
        {
            _isShooting = true;
            _lastShootTime = DateTime.Now;
            OnChanged(_isShooting);
        }

        private void FixedUpdate()
        {
            if (_isShooting && _lastShootTime.AddSeconds(_minFXTime) < DateTime.Now)
            {
                _isShooting = false;
                OnChanged(_isShooting);
            }
        }

        protected virtual void OnChanged(bool isShooting) { }
    }
}
 