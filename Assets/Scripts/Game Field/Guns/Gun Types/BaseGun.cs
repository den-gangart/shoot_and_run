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
        public bool OnReolad { get; private set; }
        protected IGunView _gunView;

        public void Initialize(GunParameters parameters)
        {
            Params = parameters;
            _gunView = GetComponent<IGunView>();
        }

        public bool TryShoot(IDamagable damagable)
        {
            if (!OnReolad)
            {
                Shoot(damagable);
                Reolad();
                return true;
            }

            return false;
        }

        protected virtual void Shoot(IDamagable damagable) 
        { 
            if(damagable != null)
            {
                damagable.TakeDamage(Params.damage);
            }

            _gunView.Shoot();
        }

        protected void Reolad()
        {
            OnReolad = true;
            StartCoroutine(ReoladRoutine());
        }

        private IEnumerator ReoladRoutine()
        {
            yield return new WaitForSeconds(Params.coolDown);
            OnReolad = false;
        }
    }
}
