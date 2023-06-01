using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Character
{

    public class CharacterBehaviour : MonoBehaviour, IDamagable, ICharacter
    {
        [SerializeField] private CharacterState _defaultState;
        [SerializeField] private CharacterType _characterType;
        [SerializeField] private float _healthMaxValue = 100f;

        private const float DESTROY_TIME = 2f;

        public CharacterType CharacterType { get { return _characterType; } }
        public CharacterStateHandler StateHandler { get; private set; }
        public Health Health { get; private set; }

        public void Initialize()
        {
            StateHandler = new CharacterStateHandler(_defaultState);
            Health = new Health(_healthMaxValue);
            Health.OnDead += OnDead;
        }

        public void Kill()
        {
            Health.Kill();
        }

        public void TakeDamage(float damage)
        {
            Health.TakeDamage(damage);
        }

        private void OnDead()
        {
            StateHandler.ChangeState(CharacterState.Dead);

            if (_characterType == CharacterType.Enemy)
            {
                StartCoroutine(DestroyRoutine());
            }
        }

        private IEnumerator DestroyRoutine()
        {
            yield return new WaitForSeconds(DESTROY_TIME);
            Destroy(this.gameObject);
        }
    }
}
