using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Data
{
    [CreateAssetMenu(fileName = "BodyPartData", menuName = "ScriptableObjects/BodyPartData")]
    public class BodyPartData : ScriptableObjectDataSaver<ItemsInfo>
    {
        public List<Sprite> heads;
        public List<Sprite> bodies;
    }
}
