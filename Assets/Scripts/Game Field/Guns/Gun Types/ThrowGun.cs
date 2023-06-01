using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Guns
{
    public class ThrowGun : BaseGun
    {
        [SerializeField] Transform _startPosition;
        [SerializeField] private Bullet _bulletPrefab;

        protected override void Shoot(IDamagable damagable)
        {
            Vector3 horizontalView = new Vector3(transform.forward.x, 0, transform.forward.z);
            var bullet = Instantiate(_bulletPrefab, _startPosition.position, transform.rotation);
            bullet.Initialize(Params.damage, horizontalView);
        }
    }
}
