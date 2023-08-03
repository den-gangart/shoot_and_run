using System;
using UnityEngine;

namespace RunShooter
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(PooledObject))]
    public class AudioSourceHandler : MonoBehaviour
    {
        public string SoundName { get; private set; }
        public event Action<AudioSourceHandler> SoundStopped;

        private AudioSource _audioSource;
        private PooledObject _pooledObject;
        private bool _isPause = false;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _pooledObject = GetComponent<PooledObject>();
        }

        private void Update()
        {
            if (!_audioSource.isPlaying && _isPause == false)
            {
                _pooledObject.ReturnToPool();
                SoundStopped?.Invoke(this);
            }
        }

        public void Initialize(AudioClip clip, AudioComponentParams component)
        {
            _audioSource.clip = clip;
            component.ApplySettingsToSource(_audioSource);
            SoundName = component.GetAssetName();
            _audioSource.Play();
        }

        public void Play()
        {
            _audioSource.Play();
            _isPause = false;
        }

        public void Stop()
        {
            _audioSource.Stop();
            _isPause = false;
        }

        public void Pause()
        {
            _audioSource.Pause();
            _isPause = true;
        }

        public void Resume()
        {
            _audioSource.UnPause();
            _isPause = false;
        }
    }
}