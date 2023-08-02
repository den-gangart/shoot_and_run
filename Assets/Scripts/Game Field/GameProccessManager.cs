using RunShooter.Character;
using RunShooter.Player;
using RunShooter.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RunShooter
{
    public class GameProccessManager
    {
        public event Action GameStarted;
        public event Action GameFinished;

        private bool _isPause;

        private int START_DELAY = 4000;
        private int FINISH_DELAY = 2000;

        private const int PAUSE_TIME_SCALE = 0;
        private const int PLAY_TIME_SCALE = 1;

        public GameProccessManager()
        {
            _isPause = false;
        }

        public async void StartGame()
        {
            await Task.Delay(START_DELAY);
            EventSystem.Broadcast(new GameFieldEvent(GameFieldEvent.ON_GAME_STARTED));
            GameStarted?.Invoke();
        }

        public async void FinishGame()
        {
            await Task.Delay(FINISH_DELAY);
            EventSystem.Broadcast(new GameFieldEvent(GameFieldEvent.ON_GAME_FINISHED));
            EventSystem.Broadcast(new SoundEvent(SoundEvent.ON_STOP_BG_MUSIC));
            GameFinished?.Invoke();
        }

        public void PausePressed()
        {
            _isPause = !_isPause;
            Time.timeScale = _isPause ? PAUSE_TIME_SCALE : PLAY_TIME_SCALE;
            EventSystem.Broadcast(new GameFieldEvent(_isPause ? GameFieldEvent.ON_GAME_PAUSE : GameFieldEvent.ON_GAME_RESUME));
        }

        public void RestartGame()
        {
            SceneLoader.Instance.LoadScene(SceneIndex.GameField);
            Time.timeScale = PLAY_TIME_SCALE;
        }

        public void ExitGame()
        {
            SceneLoader.Instance.LoadScene(SceneIndex.MainMenu);
            Time.timeScale = PLAY_TIME_SCALE;
        }
    }
}
