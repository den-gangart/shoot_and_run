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
        public event Action PausePress;
        public event Action ExitPress;
        public event Action RestartPress;

        [SerializeField] private HealthView _healthView;
        [SerializeField] private ResultPopup _resultPopup;
        [SerializeField] private TextMeshProUGUI _killCounter;
        [SerializeField] private TextMeshProUGUI _timerCounter;

        private GameStatHandler _gameStat;
        private Animator _animator;

        private readonly int _animPause = Animator.StringToHash("Pause");
        private readonly int _animFinish = Animator.StringToHash("Finish");
        private readonly int _animBack = Animator.StringToHash("Back");
        private const string TIME_FORMAT = @"mm\:ss";

        public void Initialize(GameStatHandler gameStat, PlayerObject player)
        {
            _gameStat = gameStat;
            _animator = GetComponent<Animator>();

            _gameStat.OnKill += OnKill;
            _gameStat.StopWatch.OnTick += OnTick;

            _healthView.Init(player);

            EventSystem.AddEventListener<GameFieldEvent>(OnEventRecivied);
        }

        private void OnDisable()
        {
            _gameStat.OnKill -= OnKill;
            _gameStat.StopWatch.OnTick -= OnTick;

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
            PausePress?.Invoke();
            _animator.SetTrigger(_animPause);
        }

        public void OnResumePressed()
        {
            PausePress?.Invoke();
            _animator.SetTrigger(_animBack);
        }

        public void OnRestartPressed()
        {
           RestartPress?.Invoke();
        }

        public void FinishGame()
        {
            _animator.SetTrigger(_animFinish);
            _resultPopup.Initialize(_gameStat.KilledCount, GetFormattedTime(_gameStat.StopWatch.ElapsedTime));
        }

        public void OnExitPressed()
        {
            ExitPress?.Invoke();
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
