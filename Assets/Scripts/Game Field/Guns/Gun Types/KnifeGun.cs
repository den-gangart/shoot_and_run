using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Guns
{
    public class KnifeGun : BaseGun
    {
        [SerializeField] private float _hitDistance;

        public override bool TryShoot()
        {
            if (!isReoladed())
            {
                return false;
            }

            bool isShoot = false;
            RaycastHit hit;
            Vector3 horizontalView = new Vector3(transform.forward.x, 0, transform.forward.z);

            if (Physics.Raycast(transform.position, horizontalView, out hit, Mathf.Infinity))
            {
                if (hit.distance <= _hitDistance && hit.transform.TryGetComponent(out IDamagable damagable))
                {
                    damagable.TakeDamage(Params.damage);
                    isShoot = true;
                    base.Shoot();
                }
            }

            return isShoot;
        }
    }
}
