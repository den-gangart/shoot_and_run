using UnityEngine;

namespace RunShooter.Character
{
    [RequireComponent(typeof(CharacterGun))]
    [RequireComponent(typeof(ICharacterMovement))]
    [RequireComponent(typeof(ICharacterView))]
    public class DefaultCharacterController : MonoBehaviour, IDamagable, ICharacter
    {
        public CharacterType CharacterType { get { return _characterType; } }
        public CharacterStateHandler StateHandler { get; private set; }
        public Health Health { get; private set; }

        [Header("Character Params")]
        [SerializeField] private CharacterState _defaultState;
        [SerializeField] private CharacterType _characterType;
        [SerializeField] private float _healthMaxValue = 100f;

        protected CharacterGun _characterGun;
        protected ICharacterMovement _characterMovement;
        protected ICharacterView _characterView;

        public virtual void Init()
        {
            StateHandler = new CharacterStateHandler(_defaultState);

            Health = new Health(_healthMaxValue);
            Health.OnDead += HandleDeath;
            Health.OnHealthChanged += OnHealthChanged;

            _characterView = GetComponent<ICharacterView>();

            _characterGun = GetComponent<CharacterGun>();
            _characterGun.Init(_characterView.ViewInfo.gunParent, _characterType);

            _characterMovement = GetComponent<ICharacterMovement>();
        }

        public void TakeDamage(float damage)
        {
            Health.TakeDamage(damage);
        }

        public void Kill()
        {
            Health.Kill();
        }

        public void SelectGun(int gunid)
        {
            _characterGun.SelectGun(gunid);
            _characterView.SelectGun(gunid);
        }

        protected virtual void CheckShoot()
        {
            if (_characterGun.TryShoot())
            {
                _characterView.Shoot();
            }
        }

        protected virtual void HandleDeath()
        {
            _characterView.Kill();
            _characterMovement.Kill();

            StateHandler.ChangeState(CharacterState.Dead);

            OnDead();
        }

        protected virtual void CheckMovement() { }

        protected virtual void CheckRotation() { }

        protected virtual void OnDead() { }


        private void FixedUpdate()
        {
            if(StateHandler.State == CharacterState.Idle)
            {
                CheckMovement();
                CheckRotation();
                CheckShoot();
            }    
        }

        private void OnHealthChanged(float prev, float current)
        {
            if(current < prev)
            {
                _characterView.Hit();
            }
        }
    }
}
