using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Data
{
    [System.Serializable]
    public class SavableData
    {
        public int _headIndex = -1;
        public int _bodyIndex = -1;
        public float _sfxVolume = 1.0f;
        public float _musicVolume = 1.0f;
        public int _languageIndex = 0;
    }
}
