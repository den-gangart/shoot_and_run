using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Character
{
    public class CharacterView : MonoBehaviour, ICharacterView
    {
        [SerializeField] private Animator _animator;

        private const string X_AXIS = "x";
        private const string Y_AXIS = "y";

        public void ShowMovement(Vector2 direction)
        {
            _animator.SetFloat(X_AXIS, direction.x);
            _animator.SetFloat(Y_AXIS, direction.y);
        }

        public void Kill()
        {
            
        }

        public void Shoot()
        {
          
        }

        public void SelectGun(int gunID)
        {
            
        }
    }
}