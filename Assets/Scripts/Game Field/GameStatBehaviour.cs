using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunShooter;
using TMPro;
using RunShooter.UI;
using System;

namespace RunShooter.GameProccess
{
    [RequireComponent(typeof(TimerBehaviour))]
    public class GameStatBehaviour : MonoBehaviour, IEventListener
    {
        public event Action<int> OnKill;

        public TimerBehaviour Timer => _timerBehaviour;
        public int KilledCount => _killedCount;

        private TimerBehaviour _timerBehaviour;
        private int _killedCount = 0;

        private void Awake()
        {
            _timerBehaviour = GetComponent<TimerBehaviour>();
        }

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
            else if (baseEvent.Name == GameFieldEvent.ON_ENEMY_DEAD)
            {
                OnEnemyDead();
            }
        }

        private void OnGameStarted()
        {
            _timerBehaviour.StartTimer();
        }

        private void OnGameFinished()
        {
            _timerBehaviour.StopTimer();
        }

        private void OnEnemyDead()
        {
            _killedCount++;
            OnKill?.Invoke(_killedCount);
        }
    }
}
