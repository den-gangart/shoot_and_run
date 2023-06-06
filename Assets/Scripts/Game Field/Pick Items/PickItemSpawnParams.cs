using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.GameProccess
{
    [System.Serializable]
    public class PickItemParams
    {
        public BasePickedItem item;
        [Range(0f, 100f)] public int spawnChance;
    }

    [CreateAssetMenu(fileName = "Picked item Spawn Params", menuName = "ScriptableObjects/PickItemSpawnParams_ScriptableObject")]
    public class PickItemSpawnParams : ScriptableObject
    {
        public float spawnTimeFrequency = 10f;
        public float minDistanceToPlayer = 5f;
        public float maxDistanceToPlayer = 20f;

        [SerializeField] private List<PickItemParams> _paramsList;

        public BasePickedItem GetRandomItem()
        {
            int totalSpawnChance = CalculateTotalSpawnChance();
            int randomSeed = Random.Range(0, totalSpawnChance);
            int currentWeight = 0;

            foreach (var itemParam in _paramsList)
            {
                currentWeight += itemParam.spawnChance;
                if (randomSeed <= currentWeight)
                {
                    return itemParam.item;
                }
            }

            throw new System.NullReferenceException();
        }

        private int CalculateTotalSpawnChance()
        {
            int spawnChance = 0;

            foreach(var itemParam in _paramsList)
            {
                spawnChance += itemParam.spawnChance;
            }

            return spawnChance;
        }
    }
}
