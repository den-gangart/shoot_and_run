using RunShooter.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunShooter.Character;

namespace RunShooter.Player
{
    public class PlayerController : DefaultCharacterController
    {
        private PlayerInputSystem _inputSystem;

        public void Init(PlayerInputSystem inputSystem)
        {
            _inputSystem = inputSystem;

            base.Init();
        }

        protected override void CheckMovement()
        {
            Vector2 movementAxis = _inputSystem.GetMovementAxis();
            Vector3 forward = transform.forward - Vector3.forward;
            Vector2 resultDirecion = Vector2.Reflect(movementAxis, new Vector2(forward.x, forward.z));

            _characterView.ShowMovement(resultDirecion);
            _characterMovement.Move(movementAxis);
        }

        protected override void CheckRotation()
        {
            Vector2 fireAxis = _inputSystem.GetRotationAxis();

            if (fireAxis != Vector2.zero)
            { 
                _characterMovement.Rotate(fireAxis);
            }
        }

        protected override void OnDead()
        {
            EventSystem.Broadcast(new GameFieldEvent(GameFieldEvent.ON_PLAYER_DEAD));
        }
    }
}