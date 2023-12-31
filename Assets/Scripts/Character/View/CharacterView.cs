using RunShooter.Guns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Character
{
    public class CharacterView : MonoBehaviour, ICharacterView
    {
        public CharacterViewInfo ViewInfo { get => _characterViewInfo; }

        [SerializeField] private CharacterViewInfo _characterViewInfo;
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterAnimators _animators;

        private readonly int _xAxis = Animator.StringToHash("x");
        private readonly int _yAxis = Animator.StringToHash("y");
        private readonly int _isDead = Animator.StringToHash("isDead");
        private readonly int _shoot = Animator.StringToHash("Shoot");
        private readonly int _hit = Animator.StringToHash("Hit");

        private void Awake()
        {
            _animator = _characterViewInfo.animator;
        }

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
            _animator.runtimeAnimatorController = _animators.GetController(gunID);
        }
    }
}