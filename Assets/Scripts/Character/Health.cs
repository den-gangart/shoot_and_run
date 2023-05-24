using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

namespace RunShooter.Character
{
    public class Health
    {
        public Action<float> OnHealthChanged;
        public Action OnDead;
        public float Value { get => _health; }

        private float _maxValue;
        private float _health;

        public Health(float health)
        {
            _maxValue = health;
            _health = health;
        }

        public void Add(float amount)
        {
            if (_health == _maxValue)
            {
                return;
            }

            _health += amount;
            OnHealthChanged?.Invoke(_health);
        }

        public void TakeDamage(float damage)
        {
            if(_health > damage)
            {
                OnHealthChanged?.Invoke(_health);
                return;
            }
            
            if(_health != 0)
            {
                _health -= damage;
                OnDead?.Invoke();
            }
        }

        public void Kill() => TakeDamage(_maxValue);

        public void Reset() => _health = _maxValue;
    }
}
