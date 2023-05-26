using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter
{
    public class TestDamage : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent<IDamagable>(out IDamagable damagable))
            {
                damagable.TakeDamage(25);
            }
        }
    }
}
