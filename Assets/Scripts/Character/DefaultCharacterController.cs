using RunShooter.InputSystem;
using RunShooter.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Character
{
    [RequireComponent(typeof(CharacterBehaviour))]
    [RequireComponent(typeof(ICharacterMovement))]
    [RequireComponent(typeof(ICharacterView))]
    public class DefaultCharacterController : MonoBehaviour
    {
        private CharacterBehaviour _characterBehaviour;

        protected ICharacterMovement _playerMovement;
        protected ICharacterView _characterView;
        protected CharacterStateHandler _stateHandler;

        private void Awake()
        {
            _characterBehaviour = GetComponent<CharacterBehaviour>();
            _stateHandler = _characterBehaviour.StateHandler;
            _playerMovement = GetComponent<ICharacterMovement>();
            _characterView = GetComponent<ICharacterView>();
        }

        private void FixedUpdate()
        {
            if(_stateHandler.State == CharacterState.Idle)
            {
                CheckMovement();
                CheckFire();
            }    
        }

        private void OnEnable() => _stateHandler.StateChanged += OnStateChanged;
        private void OnDisable() => _stateHandler.StateChanged -= OnStateChanged;

        private void OnStateChanged(CharacterState newState)
        {
            if(newState == CharacterState.Dead)
            {
                _characterView.Kill();
            }
        }

        protected virtual void CheckMovement() { }
        protected virtual void CheckFire() { }
    }
}
