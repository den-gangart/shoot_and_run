using RunShooter.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Player
{
    [RequireComponent(typeof(ICharacterMovement))]
    public class PlayerController : MonoBehaviour
    {
        private ICharacterMovement _playerMovement;
        private PlayerView _playerView;

        private void Awake()
        {
            _playerMovement = GetComponent<ICharacterMovement>();
            _playerView = GetComponent<PlayerView>();
        }

        private void FixedUpdate()
        {
            CheckMovement();
            CheckFire();
        }

        private void CheckMovement()
        {
            Vector2 movementAxis = PlayerInputSystem.Instance.GetMovementAxis();
            Vector3 forward = transform.forward - Vector3.forward;
            Vector2 resultDirecion = Vector2.Reflect(movementAxis, new Vector2(forward.x, forward.z));

            _playerView.Move(resultDirecion);
            _playerMovement.Move(movementAxis);
        }

        private void CheckFire()
        {
            Vector2 fireAxis = PlayerInputSystem.Instance.GetRotationAxis();

            if (fireAxis != Vector2.zero)
            { 
                _playerMovement.Rotate(fireAxis);
            }
        }
    }
}