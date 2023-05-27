using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunShooter.Guns;

namespace RunShooter.Character
{
    public class CharacterGun : MonoBehaviour
    {
        private BaseGun _gun;
        [SerializeField] private GunSelector _gunSelector;

        public bool TryShoot()
        {
            return _gun?.TryShoot() ?? false;
        }

        public void SelectGun(int id)
        {
            _gun = _gunSelector.SelectGun(id);
        }

        public void SetSelector()
        {
            _gunSelector = GetComponentInChildren<GunSelector>();
        }
    }
}
