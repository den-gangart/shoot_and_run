using RunShooter.GameProccess;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RunShooter.GameProccess
{
    public class PickItemSpawnBehaviour : BaseSpawnFactory
    {
        [SerializeField] private PickItemSpawnParams _params;
        private Transform _player;

        private void Start()
        {
            _player = Root.Instance.Player.transform;
            _waitDelay = new WaitForSeconds(_params.spawnTimeFrequency);
        }

        protected override void SpawnObject()
        {
            Instantiate(_params.GetRandomItem(), GetSpawnPosition(), Quaternion.identity);
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
