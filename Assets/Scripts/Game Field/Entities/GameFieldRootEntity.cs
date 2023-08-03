namespace RunShooter.Data
{
    public class GameFieldRootEntity : MonoEntity
    {
        private async void Start()
        {
            // Layer with Map, Player, Spawners
            GameProccessEntity gameProccessEntity = new GameProccessEntity();
            await gameProccessEntity.Init(this);
            RegisterChild(gameProccessEntity);

            // Stat for kills and time
            GameStatEntity gameStatEntity = new GameStatEntity();
            gameStatEntity.Init(gameProccessEntity.GameProccessManager);
            RegisterChild(gameStatEntity);

            // Ingame interface
            UIGameEntity uiEntity = new UIGameEntity();
            await uiEntity.Init(gameProccessEntity.GameProccessManager, gameProccessEntity.PlayerObject, gameStatEntity.GameStatHandler);
            RegisterChild(uiEntity);

            gameProccessEntity.GameProccessManager.StartGame();
        }
    }
}
