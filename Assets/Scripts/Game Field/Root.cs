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
        public PlayerObject Player { get; private set; }

        [SerializeField] private Map _mapPrefab;

        [SerializeField] private PlayerObject _playerPrefab;
        [SerializeField] private GameFieldUI _playerUIPrefab;
        [SerializeField] private GameStatBehaviour _gameStatBehaviour;

        private GameProccessManager _gameManager;

        private void Start()
        {
            Map map = Instantiate(_mapPrefab, Vector3.zero, Quaternion.identity);

            _gameManager = new GameProccessManager();

            var playerUI = Instantiate(_playerUIPrefab);
            playerUI.Initialize(_gameStatBehaviour, _gameManager);

            PlayerInputSystem playerInputSystem = new PlayerInputSystem();
            playerInputSystem.Initialize(playerUI.ScreenInput);

            SpawnPlayer(playerInputSystem, map.spawnPoint.position);
        }

        private void SpawnPlayer(PlayerInputSystem playerInputSystem, Vector3 spawnPosition)
        {
            Player = Instantiate(_playerPrefab);
            Player.name = _playerPrefab.name;
            Player.transform.position = spawnPosition;
            Player.GetComponent<PlayerController>().SetInput(playerInputSystem);
        }

        private void OnDestroy()
        {
            _gameManager.Dispose();
        }
    }
}
