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
    [RequireComponent(typeof(Animator))]
    public class GameFieldUI : MonoBehaviour, IEventListener
    {
        public ScreenInput ScreenInput { get  => _screnInput; }

        [SerializeField] private ScreenInput _screnInput;
        [SerializeField] private HealthView _healthView;
        [SerializeField] private TextMeshProUGUI _killCounter;
        [SerializeField] private TextMeshProUGUI _timerCounter;

        private GameStatBehaviour _gameStat;
        private GameProccessManager _gameManager;
        private Animator _animator;

        private readonly int _animPause = Animator.StringToHash("Pause");
        private readonly int _animFinish = Animator.StringToHash("Finish");
        private readonly int _animBack = Animator.StringToHash("Back");

        public void Initialize(GameStatBehaviour gameStat, GameProccessManager gameManager)
        {
            _gameStat = gameStat;
            _gameManager = gameManager;
            _animator = GetComponent<Animator>();
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
            else if (baseEvent.Name == GameFieldEvent.ON_GAME_FINISHED)
            {
                FinishGame();
            }
        }

        public void OnPausePressed()
        {
            _gameManager.PauseGame();
            _animator.SetTrigger(_animPause);
        }

        public void OnResumePressed()
        {
            _gameManager.ResumeGame();
            _animator.SetTrigger(_animBack);
        }

        public void OnRestartPressed()
        {
            _gameManager.RestartGame();
        }

        public void FinishGame()
        {
            _animator.SetTrigger(_animFinish);
        }

        public void OnExitPressed()
        {
            _gameManager.ExitGame();
        }
    }
}
