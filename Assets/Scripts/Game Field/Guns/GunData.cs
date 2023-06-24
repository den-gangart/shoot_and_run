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

        private int _totalChanceWeights;

        private void Awake()
        {
            CalculateTotalChanceWeights();
        }

        private void OnValidate()
        {
            CalculateTotalChanceWeights();
        }

        private void CalculateTotalChanceWeights()
        {
            _totalChanceWeights = 0;

            foreach (var gun in _gunInfoList)
            {
                _totalChanceWeights += gun.spawnChance;
            }
        }

        public GunParameters GetRandomGun()
        {
            int randomSeed = Random.Range(0, _totalChanceWeights);
            int currentWeight = 0;

            foreach (var gun in _gunInfoList)
            {
                currentWeight += gun.spawnChance;
                if (randomSeed <= currentWeight)
                {
                    return gun;
                }
            }

            throw new System.NullReferenceException();
        }
    }
}
