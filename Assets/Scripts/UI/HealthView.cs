using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RunShooter.Character;
using RunShooter.GameProccess;
using RunShooter.Player;

namespace RunShooter.UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image _heartImage;
        [SerializeField] private Slider _slider;
        private Health _health;

        private const float HEALTH_STEP = 0.01f;
        private float _currentHealth;
        private float _targetHealth;

        public void Init(PlayerObject player)
        {
            _health = player.GetComponent<DefaultCharacterController>().Health;
            _health.OnHealthChanged += OnHealthChanged;

            _currentHealth = 0;
            _targetHealth = _health.Value / _health.MaxValue;
        }

        private void OnDestroy() => _health.OnHealthChanged -= OnHealthChanged;

        private void OnHealthChanged(float prevAmout, float newAmount)
        {
            if(_health.Value == 0)
            {
                _heartImage.color = Color.black;
            }

            _targetHealth = newAmount / _health.MaxValue;
        }

        private void FixedUpdate()
        {
            if (!isHealtEquals())
            {
                float step = Mathf.Sign(_targetHealth - _currentHealth) * HEALTH_STEP;
                _currentHealth += step;
                _slider.value += step;
            }
        }

        private bool isHealtEquals() => Mathf.Abs(_targetHealth - _currentHealth) < HEALTH_STEP;
    }
}
