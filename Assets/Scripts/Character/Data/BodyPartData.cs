using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Data
{
    [CreateAssetMenu(fileName = "BodyPartData", menuName = "ScriptableObjects/BodyPartData")]
    public class BodyPartData : ScriptableObjectDataSaver<ItemsInfo>
    {
        protected override string DATA_KEY => "BodyPart"; 
        public List<Sprite> heads;
        public List<Sprite> bodies;
    }
}
