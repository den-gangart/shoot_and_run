using RunShooter.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter
{
    [CreateAssetMenu(fileName = "EnemySpawnParams", menuName = "ScriptableObjects/EnemySpawnParams_ScriptableObject")]
    public class EnemySpawnParams : ScriptableObject
    {
        public EnemyController enemyPrefab;

        public int intitialCount = 5;
        public int incrementCount = 2; 
        public float spawnDelay = 0.1f;
        public float waveDelay = 10f;
        public float minDistanceToPlayer = 10f;
        public float maxDistanceToPlayer = 30f;
    }
}
