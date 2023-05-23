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
            SetCameraPosition(_target.position);
        }

        private void FixedUpdate()
        {
            if (_target != null)
            {
                Vector3 nextPosition = Vector3.Lerp(transform.position, _target.position + _offset, _deltaTimeSpeed);
                SetCameraPosition(nextPosition);
            }
        }

        private void SetCameraPosition(Vector3 targetPos)
        {
            targetPos.y = transform.position.y;
            transform.position = targetPos;
        }
    }
}
