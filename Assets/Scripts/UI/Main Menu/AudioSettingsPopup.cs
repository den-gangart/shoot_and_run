using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RunShooter
{
    public class AudioSettingsPopup : MonoBehaviour
    {
        [SerializeField] private AudioSettings _settings;
        [SerializeField] private Slider _fxSoundSlider;
        [SerializeField] private Slider _musicSoundSlider;

        public void Start()
        {
            _fxSoundSlider.value = _settings.Value.volumeList[(int)MixerType.FX];
            _musicSoundSlider.value = _settings.Value.volumeList[(int)MixerType.Music];

            _fxSoundSlider.onValueChanged.AddListener(OnFXVolumeChanged);
            _musicSoundSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        }

        private void OnMusicVolumeChanged(float newAmount)
        {
            _settings.Value.volumeList[(int)MixerType.Music] = newAmount;
            _settings.UpdateData();
        }

        private void OnFXVolumeChanged(float newAmount)
        {
            _settings.Value.volumeList[(int)MixerType.FX] = newAmount;
            _settings.UpdateData();
        }
    }
}
