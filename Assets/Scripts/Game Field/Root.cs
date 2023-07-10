using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunShooter.UI;
using RunShooter.Character;
using RunShooter.InputSystem;
using RunShooter.Player;

namespace RunShooter.GameProccess
{
    public class Root : Singleton<Root>
    {
        [SerializeField] private EnemySpawnBehaviour _enemySpawner;
        [SerializeField] private PickItemSpawnBehaviour _pickItemsSpawner;


        [SerializeField] private Map _mapPrefab;
        [SerializeField] private PlayerObject _playerPrefab;
        [SerializeField] private GameFieldUI _playerUIPrefab;
        [SerializeField] private ScreenInput _screenInputPrefab;
        [SerializeField] private GameStatBehaviour _gameStatBehaviour;

        private GameProccessManager _gameManager;

        private void Start()
        {
            Map map = Instantiate(_mapPrefab, Vector3.zero, Quaternion.identity);

            _gameManager = new GameProccessManager();

            var screenInput = Instantiate(_screenInputPrefab);
            var player = SpawnPlayer(screenInput, map.spawnPoint.position);

            var playerUI = Instantiate(_playerUIPrefab);
            playerUI.Initialize(_gameStatBehaviour, _gameManager, player);

            _enemySpawner.Init(player);
            _pickItemsSpawner.Init(player);
        }

        private PlayerObject SpawnPlayer(ScreenInput screenInput, Vector3 spawnPosition)
        {
            PlayerInputSystem playerInputSystem = new PlayerInputSystem();
            playerInputSystem.Initialize(screenInput);

            PlayerObject player = Instantiate(_playerPrefab);
            player.name = _playerPrefab.name;
            player.transform.position = spawnPosition;

            var playerController = player.GetComponent<PlayerController>();
            playerController.Init(playerInputSystem);

            return player;
        }

        private void OnDestroy()
        {
            _gameManager.Dispose();
        }
    }
}
