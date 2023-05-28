using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Guns
{
    [RequireComponent(typeof(Animator))]
    public class AnimatedGunView : BaseGunView
    {
        private Animator _animator;
        private readonly int _animShootingState = Animator.StringToHash("Shoot");

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        protected override void SetFXParams()
        {
            _animator.SetBool(_animShootingState, _isShooting);
            base.SetFXParams();
        }
    }
}
 