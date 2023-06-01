using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Guns
{
    public interface IGun
    {
        bool TryShoot(IDamagable damagable);
    }
}
