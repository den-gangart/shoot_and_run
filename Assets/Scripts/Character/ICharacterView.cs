using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Character
{
    public interface ICharacterView
    {
        public void ShowMovement(Vector2 direction);
        public void Kill();

        public void Shoot();
        public void SelectGun(int gunID);
    }
}
