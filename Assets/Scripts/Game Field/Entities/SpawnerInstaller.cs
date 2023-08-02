using RunShooter.GameProccess;
using RunShooter.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace RunShooter.Data
{
    public class SpawnerInstaller: IDisposable
    {
        private EnemySpawner _enemySpawner;
        private PickItemSpawner _pickItemSpawner;
        private GameProccessManager _gameManager;

        public void Init(MonoBehaviour context, PlayerObject player, Map map, GameProccessManager gameManager)
        {
            _enemySpawner = new EnemySpawner(context, player, map.enemySpawnParams);
            _pickItemSpawner = new PickItemSpawner(context, player, map.pickItemSpawnParams);

            _gameManager = gameManager;
            _gameManager.GameStarted += OnStartGame;
            _gameManager.GameFinished += OnFinishGame;
        }

        private void OnStartGame()
        {
            _enemySpawner.StartSpawn();
            _pickItemSpawner.StartSpawn();
        }

        private void OnFinishGame()
        {
            _enemySpawner.StopSpawn();
            _pickItemSpawner.StopSpawn();
        }

        public void Dispose()
        {
            _gameManager.GameStarted -= OnStartGame;
            _gameManager.GameFinished -= OnFinishGame;
        }
    }
}
