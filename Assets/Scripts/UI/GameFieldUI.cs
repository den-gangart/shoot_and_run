using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunShooter.Character;
using RunShooter.InputSystem;
using RunShooter.Player;

namespace RunShooter.UI
{
    public class GameFieldUI : MonoBehaviour
    {
        public ScreenInput ScreenInput { get  => _screnInput; }

        [SerializeField] private ScreenInput _screnInput;
        [SerializeField] private HealthView _healthView;
    }
}
