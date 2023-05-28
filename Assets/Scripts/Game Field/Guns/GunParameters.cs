using RunShooter.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Guns
{
    [System.Serializable]
    public class GunParameters
    {
        public int id;
        public float damage;
        public float coolDown;

        public Texture2D Icon;
        public BaseGun Prefab;
        public CharacterAnimatorType AnimatorType;
    }
}
