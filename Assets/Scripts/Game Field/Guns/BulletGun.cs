using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace RunShooter.Guns
{
    public class BulletGun : BaseGun
    {
        public override bool TryShoot()
        {
            if(!isReoladed())
            {
                _gunView.SetShoot(false);
                return false;
            }

            bool isShoot = false;
            RaycastHit hit;
            Vector3 horizontalView = new Vector3(transform.forward.x, 0, transform.forward.z);

            if(Physics.Raycast(transform.position, horizontalView, out hit, Mathf.Infinity))
            {
                if(hit.transform.TryGetComponent(out IDamagable damagable))
                {
                    damagable.TakeDamage(Params.damage);
                    isShoot = true;
                    base.Shoot();
                    _gunView.SetShoot(true);
                }
            }

            _gunView.SetShoot(isShoot);
            return isShoot;
        }
    }
}
