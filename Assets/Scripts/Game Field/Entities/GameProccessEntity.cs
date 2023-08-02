using RunShooter.Character;
using RunShooter.GameProccess;
using RunShooter.Player;
using RunShooter.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.Localization.Platform.Android;
using UnityEngine;

namespace RunShooter.Data
{
    public class GameProccessEntity: DisposableEntity
    {
        public GameProccessManager GameProccessManager { get; private set; }
        public Map Map { get; private set; }
        public PlayerObject PlayerObject { get; private set; }

        private DefaultCharacterController _playerController;

        public async Task Init(MonoBehaviour context)
        {
            GameProccessManager = new GameProccessManager();

            MapEntity mapInstaller = new MapEntity();
            await mapInstaller.Init();
            Map = mapInstaller.Map;
            RegisterChild(mapInstaller);

            PlayerEntity playerInstaller = new PlayerEntity();
            await playerInstaller.Init(mapInstaller.Map.spawnPoint);
            PlayerObject = playerInstaller.Player;
            RegisterChild(playerInstaller);

            SpawnerInstaller spawnerInstaller = new SpawnerInstaller();
            spawnerInstaller.Init(context, playerInstaller.Player, mapInstaller.Map, GameProccessManager);
            RegisterChild(spawnerInstaller);

            _playerController = playerInstaller.Player.GetComponent<DefaultCharacterController>();
            _playerController.Health.OnDead += GameProccessManager.FinishGame;
        }

        public override void Dispose()
        {
            _playerController.Health.OnDead -= GameProccessManager.FinishGame;

            base.Dispose();
        }
    }
}
