using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter
{
    public interface IDamagable
    {
       void TakeDamage(float damage);
       void Kill();
    }
}
