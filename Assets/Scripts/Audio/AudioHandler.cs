using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

namespace RunShooter
{
    public class AudioHandler : Singleton<AudioHandler>
    {
        [SerializeField] private AudioSettings _audioSettings;
        [SerializeField] private ObjectPool _pool;

        private Dictionary<string, List<AudioSourceHandler>> _playingSoundsByNames = new Dictionary<string, List<AudioSourceHandler>>();
        private Dictionary<string, AudioClip> _cashedClips = new Dictionary<string, AudioClip>();

        private const string SOUND_ADRESS_PREF = "Assets/Sounds/";

        override protected void OnAwake()
        {
            _audioSettings.CreateAudioDictionary();
            _audioSettings.SynchronizeMixerGroups();
        }

        public async Task<AudioSourceHandler> GetAudioHanlder(string soundName)
        {
            return await InitializeSoundHandler(soundName);
        }

        public async void PlayGameSound(string soundName, GameObject sender)
        {
            AudioSourceHandler source = await InitializeSoundHandler(soundName);

            if(sender != null) 
            {
                source.transform.position = sender.transform.position;
            }

            source.Play();
        }

        public void StopGameSound(string soundName)
        {
            foreach (var source in GetSourceList(soundName))
            {
                source.Stop();
            }
        }

        public void PauseGameSound(string soundName)
        {
            foreach (var source in GetSourceList(soundName))  
            {
                source.Pause();
            }
        }

        public void ResumeGameSound(string soundName)
        {
            foreach (var source in GetSourceList(soundName))
            {
                source.Resume();
            }
        }

        public bool IsSoundPlaying(string soundName)
        {
            return GetSourceList(soundName).Count > 0;
        }

        private async Task<AudioSourceHandler> InitializeSoundHandler(string soundName)
        {
            if (!_cashedClips.ContainsKey(soundName))
            {
                await LoadClip(soundName);
            }

            AudioComponentParams audioComponent = _audioSettings.GetAudioComponent(soundName);
            AudioSourceHandler source = _pool.GetPooledObject<AudioSourceHandler>();
            source.Initialize(_cashedClips[soundName], audioComponent);
            SavePlayingSource(source, soundName);

            return source;
        }

        private async Task LoadClip(string name)
        {
            var operation = Addressables.LoadAssetAsync<AudioClip>(SOUND_ADRESS_PREF + name);
            AudioClip clip = await operation.Task;

            if (operation.Status == AsyncOperationStatus.Failed)
            {
                Debug.LogWarning("Missed sound in assets");
                _cashedClips.Add(name, null);
                return;
            }

            _cashedClips.Add(name, clip);
        }

        private List<AudioSourceHandler> GetSourceList(string soundName)
        {
            return _playingSoundsByNames[soundName];
        }

        private void OnSourceStopped(AudioSourceHandler source)
        {
            _playingSoundsByNames[source.SoundName].Remove(source);
            source.SoundStopped -= OnSourceStopped;
        }

        private void SavePlayingSource(AudioSourceHandler source, string soundName)
        {
            if (_playingSoundsByNames.ContainsKey(soundName) == false)
            {
                _playingSoundsByNames.Add(soundName, new List<AudioSourceHandler>());
            }

            _playingSoundsByNames[soundName].Add(source);
            source.SoundStopped += OnSourceStopped;
        }
    }
}