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

        protected override void OnAwake()
        {
            Map map = Instantiate(_mapPrefab, Vector3.zero, Quaternion.identity);

            PlayerInputSystem playerInputSystem = new PlayerInputSystem();

            Player = Instantiate(_playerPrefab);
            Player.name = _playerPrefab.name;
            Player.transform.position = map.spawnPoint.position;
            Player.GetComponent<PlayerController>().SetInput(playerInputSystem);

            var playerUI = Instantiate(_playerUIPrefab);
            playerUI.Initialize(_gameStatBehaviour);
            playerInputSystem.Initialize(playerUI.ScreenInput);

            StartCoroutine(StartGameRoutine());
        }

        private IEnumerator StartGameRoutine()
        {
            yield return new WaitForSeconds(2f);
            EventSystem.Broadcast(new GameFieldEvent(GameFieldEvent.ON_GAME_STARTED));
        }
    }
}
