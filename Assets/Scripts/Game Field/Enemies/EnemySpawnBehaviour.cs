using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

namespace RunShooter.GameProccess
{
    public class EnemySpawnBehaviour : BaseSpawnFactory, IEventListener
    {
        [SerializeField] private EnemySpawnParams _spawnParams;

        private Transform _player;
        private WaitForSeconds _enemySpawnDelay;
        private int _waveCount = 0;

        private void Start()
        {
            _player = Root.Instance.Player.transform;
            _waitDelay = new WaitForSeconds(_spawnParams.waveDelay);
            _enemySpawnDelay = new WaitForSeconds(_spawnParams.spawnDelay);
        }

        protected override void SpawnObject()
        {
            StartCoroutine(SpawnEnemiesRoutine());
            _waveCount++;
        }

        private IEnumerator SpawnEnemiesRoutine()
        {
            int currentEnemyCount = _spawnParams.intitialCount + _spawnParams.intitialCount * _waveCount;

            for(int i = 0; i < currentEnemyCount; i++)
            {
                Instantiate(_spawnParams.enemyPrefabs, GetSpawnPosition(), Quaternion.identity);

                yield return _enemySpawnDelay;
            }
        }

        private Vector3 GetSpawnPosition()
        {
            float spawnRadius = Random.Range(_spawnParams.minDistanceToPlayer,_spawnParams.maxDistanceToPlayer);
            Vector2 randomCircleDot = Random.insideUnitCircle * spawnRadius;
            Vector3 position = new Vector3(randomCircleDot.x, 0, randomCircleDot.y) + _player.position;

            NavMeshHit hit;
            NavMesh.SamplePosition(position, out hit, _spawnParams.minDistanceToPlayer, 1);

            return hit.position;
        }
    }
}
