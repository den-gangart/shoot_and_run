using RunShooter.GameProccess;
using RunShooter.InputSystem;
using RunShooter.Player;
using RunShooter.UI;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace RunShooter.Data
{
    public class InputSystemEntity : AssetLoaderEntity
    {
        public PlayerInputSystem Input { get; private set; }

        public async Task Init()
        {
            ScreenInput screenInput = await InstantiateAsset<ScreenInput>(GameFieldAssetPathData.SCREEN_INPUT_ADRESS);

            Input = new PlayerInputSystem();
            Input.Init(screenInput);
        }
    }
}
