using System.Collections.Generic;
using UnityEngine;
using RunShooter.Data;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace RunShooter
{
    [CreateAssetMenu(fileName = "Audio Settings", menuName = "ScriptableObjects/AudioSettings")]
    public class AudioSettings : ScriptableObjectDataSaver<MixerVolumeList>
    {
        protected override string DATA_KEY => "MixerVolumeList";

        [Header("Mixer volume")]
        [SerializeField] private List<AudioMixerInfo> _mixerList;
        [Header("Persistent Audio")]
        [SerializeField] private List<AudioComponentParams> _audioList;
        [Header("Scene audio")]
        [SerializeField] private List<List<AudioComponentParams>> _sceneAudioList;

        private Dictionary<string, AudioComponentParams> _audioComponentsByNames = new Dictionary<string, AudioComponentParams>();

        public void SynchronizeMixerGroups()
        {
            for(int i = 0; i< _mixerList.Count; i++)
            {
                _mixerList[i].SetVolume(Value.volumeList[i]);
            }
        }

        public List<string> GetPersistentSoundNames()
        {
            return GenerateNames(_audioList);
        }

        public List<string> GetSceneSoundNames(int sceneIndex)
        {
            return GenerateNames(_sceneAudioList[sceneIndex]);
        }

        public void CreateAudioDictionary()
        {
            _audioComponentsByNames = new Dictionary<string, AudioComponentParams>();

            foreach (AudioComponentParams audioComponent in _audioList)
            {
                _audioComponentsByNames.Add(audioComponent.GetAssetName(), audioComponent);
            }
        }

        public AudioComponentParams GetAudioComponent(string name)
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

        private List<string> GenerateNames(List<AudioComponentParams> audioParams)
        {
            List<string> names = new List<string>(audioParams.Count);

            foreach (var param in audioParams)
            {
                names.Add(param.GetAssetName());
            }

            return names;
        }
    }

    public enum MixerType
    {
        Master,
        Music,
        FX,
    }
}