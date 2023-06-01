using RunShooter.Guns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Character
{
    [CreateAssetMenu(fileName = "CharacterAnimators", menuName = "ScriptableObjects/CharacterAnimators_ScriptableObject")]
    public class CharacterAnimators_ScriptableObject: ScriptableObject
    {
        [SerializeField] private List<RuntimeAnimatorController> _animatorControllers;
        [SerializeField] private GunData _gunData;

        public RuntimeAnimatorController GetController(int gunid)
        {
            int controllerIndex = (int)_gunData.getData(gunid).AnimatorType;
            return _animatorControllers[controllerIndex];
        }
    }

    public enum CharacterAnimatorType
    {
        Knife = 0,
        Pistol = 1,
        Auto = 2,
        Bazooka = 3,
        Minigun = 4,
    }
}
