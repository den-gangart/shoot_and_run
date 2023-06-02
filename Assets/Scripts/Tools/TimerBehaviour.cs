using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RunShooter
{
    public class TimerBehaviour : MonoBehaviour
    {
        public string FormattedTime  => TimeSpan.FromSeconds(_elapsedTime).ToString(TIME_FORMAT);
        public bool IsPlaying => _isPlaying;

        private const string TIME_FORMAT = @"mm\:ss";
        private double _elapsedTime = 0;
        private bool _isPlaying = false;
        
        public void StartTimer()
        {
            _isPlaying = true;
            _elapsedTime = 0;
        }

        public void StopTimer()
        {
            _isPlaying = false;
        }

        private void Update()
        {
            if(_isPlaying)
            {
                _elapsedTime += Time.deltaTime;
            }
        }
    }
}
