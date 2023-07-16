using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunShooter.UI;
using RunShooter.Character;
using RunShooter.InputSystem;
using RunShooter.Player;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using RunShooter.Data;
using System.Threading.Tasks;

namespace RunShooter.GameProccess
{
    public class Root : Singleton<Root>
    {
        [SerializeField] private AssetReference _mapReference;
        [SerializeField] private AssetReference _playerReference;
        [SerializeField] private AssetReference _inGameUIReference;
        [SerializeField] private AssetReference _screenInputReference;

        [SerializeField] private GameStatBehaviour _gameStatBehaviour;

        private GameProccessManager _gameManager;
        private EnemySpawner _enemySpawner;
        private PickItemSpawner _pickItemSpawner;

        private List<AssetInstanceLoader> _loaderlist = new List<AssetInstanceLoader>();

        private async void Start()
        {
            Map map = await InitMap();

            PlayerObject player = await InitPlayer(map.spawnPoint.position);

            GameFieldUI gameFieldUI = await InitUI(player);

            InitSpawners(player, map);

            _gameManager = new GameProccessManager(player, gameFieldUI);
            _gameManager.GameStarted += OnStartGame;
            _gameManager.GameFinished += OnFinishGame;

            _gameManager.StartGame();
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

        private void InitSpawners(PlayerObject player, Map map)
        {
            _enemySpawner = new EnemySpawner(this, player, map.enemySpawnParams);
            _pickItemSpawner = new PickItemSpawner(this, player, map.pickItemSpawnParams);
        }

        private async Task<Map> InitMap()
        {
            return await CreateLoader().GetInstanceAsync<Map>(_mapReference);
        }

        private async Task<GameFieldUI> InitUI(PlayerObject player)
        {
            var playerUI = await CreateLoader().GetInstanceAsync<GameFieldUI>(_inGameUIReference);
            playerUI.Initialize(_gameStatBehaviour, player);
            return playerUI;
        }

        private async Task<PlayerObject> InitPlayer(Vector3 spawnPosition)
        {
            var playerInputSystem = await InitInputSystem();

            PlayerObject player = await CreateLoader().GetInstanceAsync<PlayerObject>(_playerReference);
            player.transform.position = spawnPosition;

            var playerController = player.GetComponent<PlayerController>();
            playerController.Init(playerInputSystem);

            return player;
        }

        private async Task<PlayerInputSystem> InitInputSystem()
        {
            var screenInput = await CreateLoader().GetInstanceAsync<ScreenInput>(_screenInputReference);

            PlayerInputSystem playerInputSystem = new PlayerInputSystem();
            playerInputSystem.Initialize(screenInput);

            return playerInputSystem;
        }

        private AssetInstanceLoader CreateLoader()
        {
            AssetInstanceLoader loader = new AssetInstanceLoader();
            _loaderlist.Add(loader);
            return loader;
        }

        private void OnDestroy()
        {
            foreach(var loader in _loaderlist)
            {
                loader.Release();
            }
        }
    }
}
