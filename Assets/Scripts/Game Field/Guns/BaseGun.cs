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
        public int Id { get => _id; }

        [SerializeField] protected GunData _gunData;
        [SerializeField] private int _id;

        protected IGunView _gunView;
        private DateTime _shotTime = DateTime.MinValue;

        private void Awake()
        {
            _gunView = GetComponent<IGunView>();
            Params = _gunData.getData(_id);
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
