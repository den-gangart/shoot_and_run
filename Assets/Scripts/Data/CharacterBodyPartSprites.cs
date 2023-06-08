using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Data
{
    [CreateAssetMenu(fileName = "Body Sprites", menuName = "ScriptableObjects/CharacterBodySprites_ScriptableObject")]
    public class CharacterBodyPartSprites : ScriptableObject
    {
        public List<Sprite> heads;
        public List<Sprite> bodies;
    }
}
