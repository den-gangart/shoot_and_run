using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter
{
    [System.Serializable]
    public class MixerVolumeList
    {
        [Range(0.001f, 1)] public List<float> volumeList;
    }
}
