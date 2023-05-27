using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RunShooter.Character;
using RunShooter.GameProccess;

namespace RunShooter.UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image _heartImage;
        [SerializeField] private Slider _slider;
        private Health _health;

        private const float HEALTH_STEP = 0.001f;

        private void Start()
        {
            _health = Root.Instance.Player.GetComponent<CharacterBehaviour>().Health;
            _health.OnHealthChanged += OnHealthChanged;
            OnHealthChanged(0, _health.Value);
        }

        private void OnDestroy() => _health.OnHealthChanged -= OnHealthChanged;

        private void OnHealthChanged(float prevAmout, float newAmount)
        {
            if(_health.Value == 0)
            {
                _heartImage.color = Color.black;
            }

            float relativeAmount = newAmount / _health.MaxValue;
            StartCoroutine(ChangeHealth(relativeAmount));
        }

        private IEnumerator ChangeHealth(float relativeAmount)
        {
            do
            {
                float step = _slider.value > relativeAmount ? -HEALTH_STEP : HEALTH_STEP;
                _slider.value += step;
                yield return null;
            } while (Mathf.Abs(_slider.value  -  relativeAmount) > HEALTH_STEP);
        }
    }
}
