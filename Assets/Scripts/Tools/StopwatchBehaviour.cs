using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RunShooter.GameProccess
{
    public class StopwatchBehaviour : MonoBehaviour
    {
        public event Action<float> OnTick;

        public bool IsPlaying => _isPlaying;
        public float ElapsedTime => _elapsedTime;

        private float _elapsedTime = 0;
        private float _prevTimeTick = 0;

        private bool _isPlaying = false;
        
        public void StartTimer()
        {
            _isPlaying = true;
            _elapsedTime = 0;
            _prevTimeTick = 0;
        }

        public void StopTimer()
        {
            _isPlaying = false;
        }

        private void Update()
        {
            if (!_isPlaying) return;


            _elapsedTime += Time.deltaTime;

            if (_elapsedTime - _prevTimeTick >= 1)
            {
                OnTick?.Invoke(_elapsedTime);
                _prevTimeTick = _elapsedTime;
            }
        }
    }
}
