using RunShooter.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Guns
{
    [System.Serializable]
    public class GunParameters
    {
        [Header("Main Info")]
        public int id;
        public float damage;
        public float coolDown;
        public float maxDistance;

        [Header("Randomizing"), Range(-1, 100)] public int spawnChance;

        [Header("View")]
        public BaseGun Prefab;
        public CharacterAnimatorType AnimatorType;
    }
}
