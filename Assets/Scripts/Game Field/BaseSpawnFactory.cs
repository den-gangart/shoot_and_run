using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.GameProccess
{
    public class BaseSpawnFactory : MonoBehaviour
    {
        private IEnumerator _activeSpawnRoutine;
        protected WaitForSeconds _waitDelay;

        private void OnEnable()
        {
            EventSystem.AddEventListener<GameFieldEvent>(OnEventRecivied);
        }

        private void OnDisable()
        {
            EventSystem.RemoveEventListener<GameFieldEvent>(OnEventRecivied);
        }

        public void OnEventRecivied(BaseEvent baseEvent)
        {
            if (baseEvent.Name == GameFieldEvent.ON_GAME_STARTED)
            {
                OnGameStarted();
            }
            else if (baseEvent.Name == GameFieldEvent.ON_GAME_FINISHED)
            {
                OnGameFinished();
            }
        }

        private void OnGameStarted()
        {
            _activeSpawnRoutine = SpawnRoutine();
            StartCoroutine(_activeSpawnRoutine);
        }


        private void OnGameFinished()
        {
            StopCoroutine(_activeSpawnRoutine);
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
