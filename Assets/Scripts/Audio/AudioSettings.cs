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

        public void SynchronizeMixerGroups()
        {
            for(int i = 0; i< _mixerList.Count; i++)
            {
                _mixerList[i].SetVolume(Value.volumeList[i]);
            }
        }

        public Dictionary<string, AudioComponent> GetAudioDictionary()
        {
            Dictionary<string, AudioComponent> audioDictionary = new Dictionary<string, AudioComponent>();

            foreach (AudioComponent audioComponent in _audioList)
            {
                audioDictionary.Add(audioComponent.GetAssetName(), audioComponent);
            }

            return audioDictionary;
        }

        protected override void OnDataUpdated()
        {
            SynchronizeMixerGroups();
        }
    }

    public enum MixerType
    {
        Master,
        Music,
        FX,
    }
}