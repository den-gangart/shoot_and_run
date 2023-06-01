using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Guns
{
    public class ThrowGun : BaseGun
    {
        [SerializeField] Transform _startPosition;
        [SerializeField] private Bullet _bulletPrefab;

        public override bool TryShoot()
        {
            if (!isReoladed())
            {
                _gunView.SetShoot(false);
                return false;
            }

            bool isShoot = false;
            RaycastHit hit;
            Vector3 horizontalView = new Vector3(transform.forward.x, 0, transform.forward.z);

            if (Physics.Raycast(transform.position, horizontalView, out hit, Mathf.Infinity))
            {
                if (hit.transform.TryGetComponent(out IDamagable damagable))
                {
                    var bullet = Instantiate(_bulletPrefab, _startPosition.position, transform.rotation);
                    bullet.Initialize(Params.damage, horizontalView);

                    base.Shoot();
                    isShoot = true;
                }
            }

            _gunView.SetShoot(isShoot);
            return isShoot;
        }
    }
}
