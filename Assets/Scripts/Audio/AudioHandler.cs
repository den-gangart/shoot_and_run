using System.Collections.Generic;
using UnityEngine;

namespace RunShooter
{
    public class AudioHandler : Singleton<AudioHandler>
    {
        [SerializeField] private AudioSettings _audioSettings;
        [SerializeField] private ObjectPool _pool;

        private Dictionary<string, AudioComponent> _audioComponentsByNames;
        private Dictionary<string, List<AudioSourceHandler>> _playingSoundsByNames;

        override protected void OnAwake()
        {
            _audioSettings.SynchronizeMixerGroups();
            _audioComponentsByNames = _audioSettings.GetAudioDictionary();
            _playingSoundsByNames = new Dictionary<string, List<AudioSourceHandler>>();
        }

        private void Start()
        {
            _audioSettings.SynchronizeMixerGroups();
        }

        public AudioSourceHandler PlayGameSound(string soundName, GameObject sender)
        {
            AudioComponent audioComponent = _audioComponentsByNames[soundName];
            AudioSourceHandler source = _pool.GetPooledObject<AudioSourceHandler>();
            source.transform.position = sender.transform.position;
            source.Initialize(audioComponent);

            SavePlayingSource(source, soundName);
            return source;
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
            return Instance.GetSourceList(soundName).Count > 0;
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