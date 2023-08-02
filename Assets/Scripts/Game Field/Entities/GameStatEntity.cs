using RunShooter.GameProccess;
using RunShooter.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter
{
    public class GameStatEntity : DisposableEntity
    {
        public GameStatHandler GameStatHandler { get; private set; }

        private GameProccessManager gameProccess;

        public void Init(GameProccessManager gameProccess)
        {
            GameObject gameObject = new GameObject("Stopwatch");
            StopwatchBehaviour stopwatch = gameObject.AddComponent<StopwatchBehaviour>();

            GameStatHandler = new GameStatHandler(stopwatch);

            this.gameProccess = gameProccess;
            gameProccess.GameFinished += GameStatHandler.OnGameFinished;
            gameProccess.GameStarted += GameStatHandler.OnGameStarted;
        }

        public override void Dispose()
        {
            gameProccess.GameFinished -= GameStatHandler.OnGameFinished;
            gameProccess.GameStarted -= GameStatHandler.OnGameStarted;

            GameStatHandler.Dispose();
            base.Dispose();
        }
    }
}
