using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.GameProccess
{
    public class BaseSpawnFactory
    {
        protected MonoBehaviour _context;
        protected WaitForSeconds _waitDelay;

        private IEnumerator _activeSpawnRoutine;

        public BaseSpawnFactory(MonoBehaviour context)
        {
            _context = context;
        }

        public void StartSpawn()
        {
            _activeSpawnRoutine = SpawnRoutine();
            _context.StartCoroutine(_activeSpawnRoutine);
        }

        public void StopSpawn()
        {
            _context.StopCoroutine(_activeSpawnRoutine);
        }

        private IEnumerator SpawnRoutine()
        {
            do
            {
                SpawnObject();

                yield return _waitDelay;

            } while (true);
        }

        protected virtual void SpawnObject() { }
    }
}
