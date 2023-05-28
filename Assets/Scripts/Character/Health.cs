using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

namespace RunShooter.Character
{
    public class Health
    {
        public Action<float, float> OnHealthChanged;
        public Action OnDead;

        public float MaxValue { get => _maxValue; }
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

            float prev = _health;
            _health = Mathf.Clamp(_health + amount, 0, _maxValue);
            OnHealthChanged?.Invoke(prev, _health);
        }

        public void TakeDamage(float damage)
        {
            if(_health == 0)
            {
                return;
            }

            float prev = _health;
            _health = damage >= _health ? 0 : _health - damage;
            OnHealthChanged?.Invoke(prev, _health);

            if (_health == 0)
            {
                OnDead?.Invoke();
            }
        }

        public void Kill() => TakeDamage(_maxValue);

        public void Reset() => _health = _maxValue;
    }
}
