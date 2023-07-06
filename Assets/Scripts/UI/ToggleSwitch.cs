using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RunShooter.UI
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Image))]
    public class ToggleSwitch : MonoBehaviour
    {
        [SerializeField] private Sprite _onSprite;
        [SerializeField] private Sprite _offSprite;
        [SerializeField] private Transform _circle;
        [SerializeField] private Transform _onPosition;
        [SerializeField] private Transform _offPosition;

        private Button _button;
        private Image _image;
        private bool _swtichValue;

        private void Start()
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
           
            _swtichValue = true;
            _button.onClick.AddListener(Swtich);
        }

        private void OnSwitched()
        {
            Sprite currentSprite = _swtichValue ? _onSprite : _offSprite;
            Vector3 currentPosition = _swtichValue ? _onPosition.position : _offPosition.position;

            _image.sprite = currentSprite;
            _circle.position = currentPosition;
        }

        public void Switch(bool value)
        {
            _swtichValue = value;
            OnSwitched();
        }

        public void Swtich()
        {
            Switch(!_swtichValue);
        }
    }
}
