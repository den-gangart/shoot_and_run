using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.InputSystem
{
    public class PlayerInputSystem
    {
        [SerializeField] private ScreenInput _screenInput;

        private const string AXIS_HORIZONTAL = "Horizontal";
        private const string AXIS_VERTICAL = "Vertical";

        public void Initialize(ScreenInput screenInput)
        {
            _screenInput = screenInput;
        }

        public Vector2 GetMovementAxis()
        {
            if (Input.anyKey && _screenInput.MovementAxis == Vector2.zero)
            {
                return new Vector2(Input.GetAxis(AXIS_HORIZONTAL), Input.GetAxis(AXIS_VERTICAL));
            }

            return _screenInput.MovementAxis;
        }

        public Vector2 GetRotationAxis()
        {
            if (Input.mousePresent && _screenInput.RotationAxis == Vector2.zero)
            {
                Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
                return ((Vector2)Input.mousePosition - screenCenter).normalized;
            }

            return _screenInput.RotationAxis;
        }
    }
}
