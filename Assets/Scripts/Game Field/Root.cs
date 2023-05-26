using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunShooter.UI;
using RunShooter.Character;
using RunShooter.InputSystem;
using RunShooter.Player;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace RunShooter.GameProccess
{
    public class Root : Singleton<Root>
    {
        public PlayerObject Player { get; private set; }

        [SerializeField] private PlayerObject _playerPrefab;
        [SerializeField] private Transform _playerSpawnPoint;

        [SerializeField] private GameFieldUI _playerUIPrefab;

        private void Start()
        {
            PlayerInputSystem playerInputSystem = new PlayerInputSystem();

            Player = Instantiate(_playerPrefab);
            Player.name = _playerPrefab.name;
            Player.transform.position = _playerSpawnPoint.position;
            Player.GetComponent<PlayerController>().SetInput(playerInputSystem);

            var playerUI = Instantiate(_playerUIPrefab);
            playerInputSystem.Initialize(playerUI.ScreenInput);
        }
    }
}
