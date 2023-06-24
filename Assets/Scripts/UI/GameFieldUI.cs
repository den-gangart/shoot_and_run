using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunShooter.Character;
using RunShooter.InputSystem;
using RunShooter.Player;
using TMPro;
using RunShooter.GameProccess;
using System;

namespace RunShooter.UI
{
    [RequireComponent(typeof(Animator))]
    public class GameFieldUI : MonoBehaviour, IEventListener
    {
        public ScreenInput ScreenInput { get  => _screnInput; }

        [SerializeField] private ScreenInput _screnInput;
        [SerializeField] private HealthView _healthView;
        [SerializeField] private ResultPopup _resultPopup;
        [SerializeField] private TextMeshProUGUI _killCounter;
        [SerializeField] private TextMeshProUGUI _timerCounter;

        private GameStatBehaviour _gameStat;
        private GameProccessManager _gameManager;
        private Animator _animator;

        private readonly int _animPause = Animator.StringToHash("Pause");
        private readonly int _animFinish = Animator.StringToHash("Finish");
        private readonly int _animBack = Animator.StringToHash("Back");
        private const string TIME_FORMAT = @"mm\:ss";

        public void Initialize(GameStatBehaviour gameStat, GameProccessManager gameManager)
        {
            _gameStat = gameStat;
            _gameManager = gameManager;
            _animator = GetComponent<Animator>();

            _gameStat.OnKill += OnKill;
            _gameStat.Timer.OnTick += OnTick;

            EventSystem.AddEventListener<GameFieldEvent>(OnEventRecivied);
        }

        private void OnDisable()
        {
            _gameStat.OnKill -= OnKill;
            _gameStat.Timer.OnTick -= OnTick;

            EventSystem.RemoveEventListener<GameFieldEvent>(OnEventRecivied);
        }

        public void OnEventRecivied(BaseEvent baseEvent)
        {
            if (baseEvent.Name == GameFieldEvent.ON_GAME_FINISHED)
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
            _resultPopup.Initialize(_gameStat.KilledCount, GetFormattedTime(_gameStat.Timer.ElapsedTime));
        }

        public void OnExitPressed()
        {
            _gameManager.ExitGame();
        }

        private void OnKill(int newKillAmount)
        {
            _killCounter.text = _gameStat.KilledCount.ToString();
        }

        private void OnTick(float elapsedTime)
        {
            _timerCounter.text = GetFormattedTime(elapsedTime);
        }

        private string GetFormattedTime(float time)
        {
            return TimeSpan.FromSeconds(time).ToString(TIME_FORMAT);
        }
    }
}
