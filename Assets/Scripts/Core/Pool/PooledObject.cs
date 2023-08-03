using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter
{
    public class PooledObject : MonoBehaviour
    {
        private ObjectPool _pool;

        public void Initialize(ObjectPool pool)
        {
            _pool = pool;
        }

        public void ReturnToPool()
        {
            _pool.ReturnPooledObject(this);
        }
    }
}
