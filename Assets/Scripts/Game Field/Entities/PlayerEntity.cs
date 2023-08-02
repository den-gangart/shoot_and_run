using RunShooter.GameProccess;
using RunShooter.InputSystem;
using RunShooter.Player;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace RunShooter.Data
{
    public class PlayerEntity : AssetLoaderEntity
    {
        public PlayerObject Player { get; private set; }

        public async Task Init(Transform spawnPoint)
        {
            InputSystemEntity inputSystemEntity = new InputSystemEntity();
            await inputSystemEntity.Init();
            RegisterChild(inputSystemEntity);

            Player = await InstantiateAsset<PlayerObject>(GameFieldAssetPathData.PLAYER_ADRESS);
            Player.transform.position = spawnPoint.position;
            Player.GetComponent<PlayerController>().Init(inputSystemEntity.Input);
        }
    }
}
