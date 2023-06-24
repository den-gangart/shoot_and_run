using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Advertisements;

namespace RunShooter.Services
{
    public class InterstitialAdsBehaviour : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        private const string ANDROID_ID = "Interstitial_Android";
        private const string IOS_ID = "Interstitial_iOS";

        private string _adsId;

        private void Awake()
        {
            _adsId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? IOS_ID
            : ANDROID_ID;
        }

        public void LoadAd()
        {
            Debug.Log("Loading Ad: " + _adsId);
            Advertisement.Load(_adsId, this);
        }

        public void ShowAd()
        {
            
            Debug.Log("Showing Ad: " + _adsId);
            Advertisement.Show(_adsId, this);
        }

        public void OnUnityAdsAdLoaded(string adUnitId)
        {
            
        }

        public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message)
        {
            Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
        }

        public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message)
        {
            Debug.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}");
        }

        public void OnUnityAdsShowStart(string _adUnitId) { }
        public void OnUnityAdsShowClick(string _adUnitId) { }
        public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState) { }

        public void OnInitializationComplete()
        {
            Debug.Log("Unity Ads initialization complete.");
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
        }
    }
}
