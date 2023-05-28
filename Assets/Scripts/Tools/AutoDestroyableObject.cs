using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter
{
    public class AutoDestroyableObject : MonoBehaviour
    {
        [SerializeField] private float _destroyTime;

        private void Start()
        {
            StartCoroutine(DestroyRoutine());
        }

        private IEnumerator DestroyRoutine()
        {
            yield return new WaitForSeconds(_destroyTime);
            Destroy(this.gameObject);
        }
    }
}
