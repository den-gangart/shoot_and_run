using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RunShooter
{
    public class GameProccessManager: IDisposable
    {
        private int START_DELAY = 4000;
        private int FINISH_DELAY = 2000;

        private const int PAUSE_TIME_SCALE = 0;
        private const int PLAY_TIME_SCALE = 1;

        public GameProccessManager()
        {
            StartGame();
            EventSystem.AddEventListener<GameFieldEvent>(OnGameEventHandler);
        }

        public void Dispose()
        {
            EventSystem.RemoveEventListener<GameFieldEvent>(OnGameEventHandler);
        }

        private void OnGameEventHandler(BaseEvent baseEvent)
        {
            if(baseEvent.Name == GameFieldEvent.ON_PLAYER_DEAD)
            {
                FinishGame();
            }
        }

        private async void StartGame()
        {
            await Task.Delay(START_DELAY);
            EventSystem.Broadcast(new GameFieldEvent(GameFieldEvent.ON_GAME_STARTED));
        }

        private async void FinishGame()
        {
            await Task.Delay(FINISH_DELAY);
            EventSystem.Broadcast(new GameFieldEvent(GameFieldEvent.ON_GAME_FINISHED));
            EventSystem.Broadcast(new SoundEvent(SoundEvent.ON_STOP_BG_MUSIC));
        }

        public void PauseGame()
        {
            Time.timeScale = PAUSE_TIME_SCALE;
            EventSystem.Broadcast(new GameFieldEvent(GameFieldEvent.ON_GAME_PAUSE));
        }

        public void ResumeGame()
        {
            Time.timeScale = PLAY_TIME_SCALE;
            EventSystem.Broadcast(new GameFieldEvent(GameFieldEvent.ON_GAME_RESUME));
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
