using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Character
{
    public enum CharacterType
    {
        Player,
        Enemy,
    }

    public class CharacterBehaviour : MonoBehaviour, IDamagable
    {
        [SerializeField] private CharacterState _defaultState;
        [SerializeField] private CharacterType _characterType;
        [SerializeField] private float _healthMaxValue = 100f;

        public CharacterStateHandler StateHandler { get; private set; }
        public Health Health { get; private set; }

        private void Start()
        {
            StateHandler = new CharacterStateHandler(_defaultState);
            Health = new Health(_healthMaxValue);
        }

        public void Kill()
        {
            Health.Kill();
        }

        public void TakeDamage(float damage)
        {
            Health.TakeDamage(damage);
        }
    }
}
