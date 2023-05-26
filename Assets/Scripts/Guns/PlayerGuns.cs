using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Guns
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerGuns", order = 1)]
    public class PlayerGuns : ScriptableObject
    {
        [SerializeField] private List<GunParameters> gunParameters;
    }
}
