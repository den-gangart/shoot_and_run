using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RunShooter
{
    [RequireComponent(typeof(AudioHandler))]
    public class SceneBackgroundSound : MonoBehaviour
    {
        [SerializeField] private List<SceneBackgroundSoundSettings> _sceneSoundsSettingList;

        private SceneBackgroundSoundSettings _currentSceneSettings;
        private AudioSourceHandler _currentSourceHandler;
        private int _currentSoundIndex = 0;

        private void Start()
        {
            // SetCurrentSceneSettings(SceneManager.GetActiveScene().name);
            // PlayCurrentSound();
        }

        private void OnEnable()
        {
            EventSystem.AddEventListener<GameFieldEvent>(OnGameFieldEvent);
            EventSystem.AddEventListener<SoundEvent>(OnSoundEvent);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            EventSystem.RemoveEventListener<GameFieldEvent>(OnGameFieldEvent);
            EventSystem.RemoveEventListener<SoundEvent>(OnSoundEvent);
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnGameFieldEvent(GameFieldEvent gameFieldEvent) 
        {
            if(gameFieldEvent.Name == GameFieldEvent.ON_GAME_PAUSE)
            {
                OnGamePaused();
            }
            else if (gameFieldEvent.Name == GameFieldEvent.ON_GAME_RESUME)
            {
                OnGameResumed();
            }
        }

        private void OnSoundEvent(SoundEvent soundEvent)
        {
            if (soundEvent.Name == SoundEvent.ON_STOP_BG_MUSIC)
            {
                OnStop();
            }
            else if (soundEvent.Name == SoundEvent.ON_PLAY_BG_MUSIC)
            {
                OnPlay();
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (_currentSourceHandler != null)
            {
                OnStop();
            }

            SetCurrentSceneSettings(scene.name);
            PlayCurrentSound();
        }

        private void SetCurrentSceneSettings(string sceneName)
        {
            foreach (var sceneSettings in _sceneSoundsSettingList)
            {
                if (sceneName.Equals(sceneSettings.GetName()))
                {
                    _currentSceneSettings = sceneSettings;
                    break;
                }
            }
        }

        private void OnBackgroundSoundStopped(AudioSourceHandler source)
        {
            source.SoundStopped -= OnBackgroundSoundStopped;
            PlayCurrentSound();
        }

        private void OnGamePaused()
        {
            _currentSourceHandler?.Pause();
        }

        private void OnGameResumed()
        {
            _currentSourceHandler?.Resume();
        }

        private void OnStop()
        {
            if (_currentSourceHandler != null)
            {
                _currentSourceHandler.SoundStopped -= OnBackgroundSoundStopped;
                _currentSourceHandler.Stop();
            }
        }

        private void OnPlay()
        {
            OnStop();
            PlayCurrentSound();
        }

        private async void PlayCurrentSound()
        {
            int soundCount = _currentSceneSettings.GetSoundCount();

            switch (_currentSceneSettings.GetSoundSequenceType())
            {
                case SoundSequenceType.Random:
                    _currentSoundIndex = Random.Range(0, soundCount);
                    break;
                case SoundSequenceType.Successively:
                    _currentSoundIndex++;

                    if (_currentSoundIndex >= soundCount)
                    {
                        _currentSoundIndex = 0;
                    }
                    break;
            }

            string currentSound = _currentSceneSettings.GetSound(_currentSoundIndex);

            _currentSourceHandler = await AudioHandler.Instance.GetAudioHanlder(currentSound);
            _currentSourceHandler.Play();
            _currentSourceHandler.SoundStopped += OnBackgroundSoundStopped;
        }
    }
}