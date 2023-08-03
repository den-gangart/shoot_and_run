using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Player
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField, Range(0, 1)] private float _deltaTimeSpeed;
        private Transform _target;

        public void SetTarget(CameraTarget target)
        {
            _target = target.transform;
            SetCameraPosition();
        }

        private void FixedUpdate()
        {
            if (_target != null)
            {
                SetCameraPosition();
            }
        }

        private void SetCameraPosition()
        {
            Vector3 nextPosition = Vector3.Lerp(transform.position, _target.position + _offset, _deltaTimeSpeed);
            transform.position = nextPosition;
        }
    }
}
