using UnityEngine;
using UnityEngine.Audio;

namespace RunShooter
{
    [System.Serializable]
    public class AudioComponentParams
    {
        [Header("Main Info")]

        [SerializeField] private string _assetName;
        [SerializeField] private AudioMixerGroup _mixerGroup;

        [Header("Parameters")]
        [SerializeField, Range(0, 1)] private float _volume = 1f;
        [SerializeField] private bool _loop = false;
        [SerializeField, Range(0, 1)] private float _spatialBlend = 0f;

        public void ApplySettingsToSource(AudioSource audioSource)
        {
            audioSource.outputAudioMixerGroup = _mixerGroup;
            audioSource.volume = _volume;
            audioSource.loop = _loop;
            audioSource.spatialBlend = _spatialBlend;
        }

        public string GetAssetName()
        {
            return _assetName;
        }
    }
}