using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RunShooter.Character
{
    public enum CharacterState
    {
        Idle,
        Blocked,
        Dead,
    }

    public class CharacterStateHandler
    {
        public event Action<CharacterState> StateChanged;
        public CharacterState State { get => _state; }

        private CharacterState _state;

        public CharacterStateHandler(CharacterState state) => ChangeState(state);

        public void ChangeState(CharacterState state)
        {
            if (_state == state)
            {
                return;
            }

            _state = state;
            StateChanged?.Invoke(state);
        }
    }
}
