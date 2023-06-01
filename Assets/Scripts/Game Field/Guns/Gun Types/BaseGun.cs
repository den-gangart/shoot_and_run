using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RunShooter.Guns
{
    [RequireComponent(typeof(IGunView))]
    public class BaseGun : MonoBehaviour, IGun
    {
        public GunParameters Params { get; private set; }

        protected IGunView _gunView;
        private DateTime _shotTime = DateTime.MinValue;

        public void Initialize(GunParameters parameters)
        {
            Params = parameters;
            _gunView = GetComponent<IGunView>();
        }

        public virtual bool TryShoot()
        {
            if (isReoladed())
            {
                Shoot();
                return true;
            }

            return false;
        }

        protected bool isReoladed() => _shotTime.AddSeconds(Params.coolDown) < DateTime.Now;

        protected virtual void Shoot() 
        {
            _shotTime = DateTime.Now;
        }
    }
}
