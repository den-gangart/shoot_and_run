using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.InputSystem
{
    public class ScreenInput : MonoBehaviour
    {
        public Vector2 MovementAxis => _movementJoyStick.Direction;
        public Vector2 RotationAxis => _rotationJoyStick.Direction;

        [SerializeField] private Joystick _movementJoyStick;
        [SerializeField] private Joystick _rotationJoyStick;
    }
}
