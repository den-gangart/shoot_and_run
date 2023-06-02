using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunShooter.Character;
using RunShooter.InputSystem;
using RunShooter.Player;
using TMPro;
using RunShooter.GameProccess;

namespace RunShooter.UI
{
    public class GameFieldUI : MonoBehaviour, IEventListener
    {
        public ScreenInput ScreenInput { get  => _screnInput; }

        [SerializeField] private ScreenInput _screnInput;
        [SerializeField] private HealthView _healthView;
        [SerializeField] private TextMeshProUGUI _killCounter;
        [SerializeField] private TextMeshProUGUI _timerCounter;

        private GameStatBehaviour _gameStat;

        public void Initialize(GameStatBehaviour gameStat)
        {
            _gameStat = gameStat;
        }

        public void Update()
        {
            if(_gameStat.Timer.IsPlaying)
            {
                _timerCounter.text = _gameStat.Timer.FormattedTime;
            }
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
            if (baseEvent.Name == GameFieldEvent.ON_ENEMY_DEAD)
            {
                _killCounter.text = _gameStat.KilledCount.ToString();
            }
        }
    }
}
