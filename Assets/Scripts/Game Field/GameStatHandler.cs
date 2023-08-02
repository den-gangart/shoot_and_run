using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunShooter;
using TMPro;
using RunShooter.UI;
using System;

namespace RunShooter.GameProccess
{ 
    public class GameStatHandler: IDisposable
    {
        public event Action<int> OnKill;

        public StopwatchBehaviour StopWatch => _stopwatch;
        public int KilledCount => _killedCount;

        private StopwatchBehaviour _stopwatch;
        private int _killedCount;

        public GameStatHandler(StopwatchBehaviour stopwatch)
        {
            _stopwatch = stopwatch;
            _killedCount = 0;

            EventSystem.AddEventListener<GameFieldEvent>(OnEventRecivied);
        }

        public void Dispose()
        {
            EventSystem.RemoveEventListener<GameFieldEvent>(OnEventRecivied);
        }

        public void OnEventRecivied(BaseEvent baseEvent)
        {
            if (baseEvent.Name == GameFieldEvent.ON_ENEMY_DEAD)
            {
                OnEnemyDead();
            }
        }

        public void OnGameStarted()
        {
            _stopwatch.StartTimer();
        }

        public void OnGameFinished()
        {
            _stopwatch.StopTimer();
        }

        private void OnEnemyDead()
        {
            _killedCount++;
            OnKill?.Invoke(_killedCount);
        }
    }
}
