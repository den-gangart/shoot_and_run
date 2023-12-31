using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RunShooter.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LoadScreen : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _loadText;

        private CanvasGroup _canvasGroup;

        private const float FADE_STEP = 0.1f;
        private const float LOAD_STEP = 0.01f;
        private const float LOAD_FINISH_AMOUNT = 1f;
        private const string TEXT_FORMAT = "{0}%";

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Show()
        {
            StartCoroutine(FakeLoadRoutine());
        }

        private IEnumerator FakeLoadRoutine()
        {
            float value = 0;

            SetLoadFields(value);

            yield return StartCoroutine(FadeIn()); 

            do
            {
                value += LOAD_STEP;
                SetLoadFields(value);
                yield return null;

            } while (value < LOAD_FINISH_AMOUNT);

            yield return StartCoroutine(FadeOut());
        }

        private IEnumerator FadeIn()
        {
            _canvasGroup.blocksRaycasts = true;

            do
            {
                _canvasGroup.alpha += FADE_STEP;
                yield return null;

            } while (_canvasGroup.alpha < LOAD_FINISH_AMOUNT);
        }

        private IEnumerator FadeOut()
        {
            do
            {
                _canvasGroup.alpha -= FADE_STEP;
                yield return null;

            } while (_canvasGroup.alpha > 0);

            _canvasGroup.blocksRaycasts = false;
        }

        public void SetLoadFields(float value)
        {
            _slider.value = value;
            _loadText.text = string.Format(TEXT_FORMAT, (int)(value * 100));
        }
    }
}
