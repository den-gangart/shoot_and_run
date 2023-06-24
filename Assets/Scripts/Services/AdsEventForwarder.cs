using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Services
{
    [RequireComponent(typeof(InterstitialAdsBehaviour))]
    public class AdsEventForwarder : MonoBehaviour
    {
        private InterstitialAdsBehaviour _interstitialAds;

        private void Start()
        {
            _interstitialAds = GetComponent<InterstitialAdsBehaviour>();
        }

        private void OnEnable()
        {
            EventSystem.AddEventListener<GameFieldEvent>(OnGameEvent);
        }

        private void OnDisable()
        {
            EventSystem.RemoveEventListener<GameFieldEvent>(OnGameEvent);
        }

        private void OnGameEvent(BaseEvent baseEvent)
        {
            if(baseEvent.Name == GameFieldEvent.ON_GAME_FINISHED)
            {
                _interstitialAds.ShowAd();
            }
            else if (baseEvent.Name == GameFieldEvent.ON_GAME_STARTED)
            {
                _interstitialAds.LoadAd();
            }
        }
    }
}
