using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace RunShooter
{
    [System.Serializable]
    public class AudioMixerInfo
    {
        [SerializeField] private AudioMixer _mixer;
        [SerializeField] private string _paramName;

        private const int VOLUME_INCREASE_AMOUNT = 20;

        public void SetVolume(float volume)
        {
            _mixer.SetFloat(_paramName, Mathf.Log(volume) * VOLUME_INCREASE_AMOUNT);
        }
    }
}
