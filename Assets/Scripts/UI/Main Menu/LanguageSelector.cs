using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace RunShooter.UI
{
    [RequireComponent(typeof(Button))]
    public class LanguageSelector : MonoBehaviour
    {
        private Button _button;
        private int _selectedIndex;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnChangeLanguage);

            _selectedIndex = LocalizationSettings.AvailableLocales.Locales.IndexOf(LocalizationSettings.SelectedLocale);
        }

        private void OnChangeLanguage()
        {
            var locales = LocalizationSettings.AvailableLocales.Locales;
            _selectedIndex = locales.Count - 1 > _selectedIndex ? _selectedIndex + 1 : 0;

            LocalizationSettings.SelectedLocale = locales[_selectedIndex];
        }
    }
}
