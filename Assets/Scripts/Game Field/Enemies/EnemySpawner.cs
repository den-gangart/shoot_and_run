using RunShooter.Player;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

namespace RunShooter.GameProccess
{
    public class EnemySpawner : BaseSpawnFactory
    {
        private EnemySpawnParams _spawnParams;
        private PlayerObject _player;
        private WaitForSeconds _enemySpawnDelay;
        private int _waveCount = 0;

        public EnemySpawner(MonoBehaviour context, PlayerObject player, EnemySpawnParams spawnParams) : base(context) 
        {
            _player = player;
            _spawnParams = spawnParams;

            _waitDelay = new WaitForSeconds(_spawnParams.waveDelay);
            _enemySpawnDelay = new WaitForSeconds(_spawnParams.spawnDelay);
        }

        protected override void SpawnObject()
        {
            _context.StartCoroutine(SpawnEnemiesRoutine());
            _waveCount++;
        }

        private IEnumerator SpawnEnemiesRoutine()
        {
            int currentEnemyCount = _spawnParams.intitialCount + _spawnParams.intitialCount * _waveCount;

            for(int i = 0; i < currentEnemyCount; i++)
            {
                var enemy = Object.Instantiate(_spawnParams.enemyPrefab, GetSpawnPosition(), Quaternion.identity);
                enemy.Init(_player);

                yield return _enemySpawnDelay;
            }
        }

        private Vector3 GetSpawnPosition()
        {
            float spawnRadius = Random.Range(_spawnParams.minDistanceToPlayer,_spawnParams.maxDistanceToPlayer);
            Vector2 randomCircleDot = Random.insideUnitCircle * spawnRadius;
            Vector3 position = new Vector3(randomCircleDot.x, 0, randomCircleDot.y) + _player.transform.position;

            NavMeshHit hit;
            NavMesh.SamplePosition(position, out hit, _spawnParams.minDistanceToPlayer, 1);

            return hit.position;
        }
    }
}
