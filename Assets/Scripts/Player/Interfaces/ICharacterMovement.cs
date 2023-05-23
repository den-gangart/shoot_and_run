using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Player
{
    public interface ICharacterMovement
    {
        void Move(Vector2 axis);
        void Rotate(Vector2 axis);
    }
}