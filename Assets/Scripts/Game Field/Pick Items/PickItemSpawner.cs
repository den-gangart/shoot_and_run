using RunShooter.GameProccess;
using RunShooter.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Platform.Android;
using UnityEngine;
using UnityEngine.AI;

namespace RunShooter.GameProccess
{
    public class PickItemSpawner : BaseSpawnFactory
    {
        private PickItemSpawnParams _params;
        private Transform _player;

        public PickItemSpawner(MonoBehaviour context, PlayerObject player, PickItemSpawnParams spawnParams) : base(context) 
        {
            _player = player.transform;
            _params = spawnParams;
            _waitDelay = new WaitForSeconds(_params.spawnTimeFrequency);
        }

        protected override void SpawnObject()
        {
            Object.Instantiate(_params.GetRandomItem(), GetSpawnPosition(), Quaternion.identity);
        }

        private Vector3 GetSpawnPosition()
        {
            float spawnRadius = Random.Range(_params.minDistanceToPlayer, _params.maxDistanceToPlayer);
            Vector2 randomCircleDot = Random.insideUnitCircle * spawnRadius;
            Vector3 position = new Vector3(randomCircleDot.x, 0, randomCircleDot.y) + _player.position;

            NavMeshHit hit;
            NavMesh.SamplePosition(position, out hit, _params.minDistanceToPlayer, 1);

            return hit.position + Vector3.up;
        }
    }
}
