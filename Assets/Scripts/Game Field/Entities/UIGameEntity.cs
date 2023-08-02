using RunShooter.GameProccess;
using RunShooter.Player;
using RunShooter.UI;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace RunShooter.Data
{
    public class UIGameEntity : AssetLoaderEntity
    {
        public GameFieldUI UI { get; private set; }

        private GameProccessManager gameProccess;

        public async Task Init(GameProccessManager gameProccess, PlayerObject player, GameStatHandler gameStat)
        {
            UI = await InstantiateAsset<GameFieldUI>(GameFieldAssetPathData.GAME_FIELD_UI_ADRESS);
            UI.Initialize(gameStat, player);

            this.gameProccess = gameProccess;

            UI.PausePress += gameProccess.PausePressed;
            UI.RestartPress += gameProccess.RestartGame;
            UI.ExitPress += gameProccess.ExitGame;
        }

        public override void Dispose()
        {
            UI.PausePress -= gameProccess.PausePressed;
            UI.RestartPress -= gameProccess.RestartGame;
            UI.ExitPress -= gameProccess.ExitGame;

            base.Dispose();
        }
    }
}
