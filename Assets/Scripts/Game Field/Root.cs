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

        [SerializeField] private PlayerObject _playerPrefab;
        [SerializeField] private Transform _playerSpawnPoint;

        [SerializeField] private GameFieldUI _playerUIPrefab;
        [SerializeField] private GameStatBehaviour _gameStatBehaviour;

        protected override void OnAwake()
        {
            PlayerInputSystem playerInputSystem = new PlayerInputSystem();

            Player = Instantiate(_playerPrefab);
            Player.name = _playerPrefab.name;
            Player.transform.position = _playerSpawnPoint.position;
            Player.GetComponent<PlayerController>().SetInput(playerInputSystem);

            var playerUI = Instantiate(_playerUIPrefab);
            playerUI.Initialize(_gameStatBehaviour);
            playerInputSystem.Initialize(playerUI.ScreenInput);

            StartCoroutine(StartGameRoutine());
        }

        private IEnumerator StartGameRoutine()
        {
            yield return new WaitForSeconds(1f);
            EventSystem.Broadcast(new GameFieldEvent(GameFieldEvent.ON_GAME_STARTED));
        }
    }
}
