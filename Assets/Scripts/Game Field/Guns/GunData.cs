using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Guns
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GunData_ScriptableObject")]
    public class GunData : ScriptableObject
    {
        [SerializeField] private List<GunParameters> _gunInfoList;

        public GunParameters getData(int id) => _gunInfoList.Find(gun => gun.id == id);
    }
}
