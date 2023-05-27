using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Character
{
    public class CharacterView : MonoBehaviour, ICharacterView
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private List<RuntimeAnimatorController> _controllers;

        private readonly int _xAxis = Animator.StringToHash("x");
        private readonly int _yAxis = Animator.StringToHash("y");
        private readonly int _isDead = Animator.StringToHash("isDead");
        private readonly int _shoot = Animator.StringToHash("Shoot");
        private readonly int _hit = Animator.StringToHash("Hit");


        public void ShowMovement(Vector2 direction)
        {
            _animator.SetFloat(_xAxis, direction.x);
            _animator.SetFloat(_yAxis, direction.y);
        }

        public void Kill()
        {
            _animator.SetBool(_isDead, true);
        }

        public void Shoot()
        {
            _animator.SetTrigger(_shoot);
        }

        public void Hit()
        {
            _animator.SetTrigger(_hit);
        }

        public void SelectGun(int gunID)
        {
            
        }
    }
}