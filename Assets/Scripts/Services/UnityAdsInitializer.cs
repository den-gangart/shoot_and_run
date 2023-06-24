using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Advertisements;

namespace RunShooter.Services
{
    public class UnityAdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
    {
        private const string ANDROID_DEVICE_ID = "5317063";
        private const string IOS_DEVICE_ID = "5317062";

        private string _gameId;
        private bool _testMode = true;

        private void Awake()
        {
            InitializeAds();
        }

        public void InitializeAds()
        {
            _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
                        ? IOS_DEVICE_ID
                        : ANDROID_DEVICE_ID;

            Debug.Log(_gameId);

            if (!Advertisement.isInitialized && Advertisement.isSupported)
            {
                Advertisement.Initialize(_gameId, _testMode, this);
            }
        }

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
