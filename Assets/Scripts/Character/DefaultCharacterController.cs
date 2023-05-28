using RunShooter.InputSystem;
using RunShooter.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Character
{
    [RequireComponent(typeof(CharacterBehaviour))]
    [RequireComponent(typeof(CharacterGun))]
    [RequireComponent(typeof(ICharacterMovement))]
    [RequireComponent(typeof(ICharacterView))]
    public class DefaultCharacterController : MonoBehaviour
    {
        private CharacterBehaviour _characterBehaviour;
        protected CharacterGun _characterGun;
        protected ICharacterMovement _playerMovement;
        protected ICharacterView _characterView;
        protected CharacterStateHandler _stateHandler;

        private void Awake()
        {
            _characterBehaviour = GetComponent<CharacterBehaviour>();
            _characterBehaviour.Initialize();

            _characterView = GetComponent<ICharacterView>();

            _characterGun = GetComponent<CharacterGun>();
            _characterGun.Initialize(_characterView.ViewInfo.gunParent);

            _stateHandler = _characterBehaviour.StateHandler;
            _playerMovement = GetComponent<ICharacterMovement>();
        }

        private void FixedUpdate()
        {
            if(_stateHandler.State == CharacterState.Idle)
            {
                CheckMovement();
                CheckRotation();
                CheckShoot();
            }    
        }

        private void OnEnable()
        {
            _stateHandler.StateChanged += OnStateChanged;
            _characterBehaviour.Health.OnHealthChanged += OnHealthChanged;
        }
        private void OnDisable()
        {
            _stateHandler.StateChanged -= OnStateChanged;
            _characterBehaviour.Health.OnHealthChanged -= OnHealthChanged;
        }

        private void OnStateChanged(CharacterState newState)
        {
            if(newState == CharacterState.Dead)
            {
                _characterView.Kill();
            }
        }

        private void OnHealthChanged(float prev, float current)
        {
            if(current < prev)
            {
                _characterView.Hit();
            }
        }

        private void CheckShoot()
        {
            if(_characterGun.TryShoot())
            {
                _characterView.Shoot();
            }
        }

        public void SelectGun(int gunid)
        {
            _characterGun.SelectGun(gunid);
        }

        protected virtual void CheckMovement() { }
        protected virtual void CheckRotation() { }
    }
}
