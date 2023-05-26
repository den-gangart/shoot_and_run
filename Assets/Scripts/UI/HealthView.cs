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

        private void Start()
        {
            _health = Root.Instance.Player.GetComponent<CharacterBehaviour>().Health;
            _health.OnHealthChanged += OnHealthChanged;
            OnHealthChanged(_health.Value);
        }

        private void OnDestroy() => _health.OnHealthChanged -= OnHealthChanged;

        private void OnHealthChanged(float newAmount)
        {
            if(_health.Value == 0)
            {
                _heartImage.color = Color.black;
            }

            float relativeAmount = newAmount / _health.MaxValue;
            _slider.value = relativeAmount;
        }
    }
}
