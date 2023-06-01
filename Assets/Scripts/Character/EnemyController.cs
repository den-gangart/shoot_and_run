using RunShooter.GameProccess;
using RunShooter.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Character
{
    public class EnemyController : DefaultCharacterController
    {
        private PlayerObject _playerObject;

        private void Start()
        {
            _playerObject = Root.Instance.Player;
        }

        protected override void CheckMovement()
        {
            Vector2 movementAxis = GetForwardToPlayer();
            Vector3 forward = transform.forward - Vector3.forward;
            Vector2 resultDirecion = Vector2.Reflect(movementAxis, new Vector2(forward.x, forward.z));

            _characterView.ShowMovement(resultDirecion);
            _playerMovement.Move(movementAxis);
        }

        protected override void CheckRotation()
        {
            _playerMovement.Rotate(GetForwardToPlayer());
        }

        private Vector2 GetForwardToPlayer()
        {
            Vector3 directionToPlayer = (_playerObject.transform.position - transform.position).normalized;
            return new Vector2(directionToPlayer.x, directionToPlayer.z);
        }
    }
}
