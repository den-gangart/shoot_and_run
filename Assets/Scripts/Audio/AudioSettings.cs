using System.Collections.Generic;
using UnityEngine;
using RunShooter.Data;
using UnityEngine.Audio;

namespace RunShooter
{
    [CreateAssetMenu(fileName = "Audio Settings", menuName = "ScriptableObjects/AudioSettings")]
    public class AudioSettings : ScriptableObjectDataSaver<MixerVolumeList>
    {
        protected override string DATA_KEY => "MixerVolumeList";

        [SerializeField] private List<AudioMixerInfo> _mixerList;
        [SerializeField] private List<AudioComponent> _audioList;
        private Dictionary<string, AudioComponent> _audioComponentsByNames;

        public void SynchronizeMixerGroups()
        {
            for(int i = 0; i< _mixerList.Count; i++)
            {
                _mixerList[i].SetVolume(Value.volumeList[i]);
            }
        }

        public void CreateAudioDictionary()
        {
            _audioComponentsByNames = new Dictionary<string, AudioComponent>();

            foreach (AudioComponent audioComponent in _audioList)
            {
                _audioComponentsByNames.Add(audioComponent.GetAssetName(), audioComponent);
            }
        }

        public AudioComponent GetAudioComponent(string name)
        {
            return _audioComponentsByNames[name];
        }

        protected override void OnDataUpdated()
        {
            SynchronizeMixerGroups();
        }

        protected override void SetInitialData()
        {
            _data = new MixerVolumeList();
            _data.volumeList = new List<float>();

            for (int i = 0; i < _mixerList.Count; i++)
            {
                _data.volumeList.Add(1f);
            }
        }
    }

    public enum MixerType
    {
        Master,
        Music,
        FX,
    }
}