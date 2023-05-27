using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunShooter.Guns;

namespace RunShooter.Character
{
    public class CharacterGun : MonoBehaviour
    {
        [SerializeField] private GunData _gunData;
        private Transform _gunParent;
        private BaseGun _gun;

        public void Initialize(Transform gunParent)
        {
            _gunParent = gunParent;
        }

        public bool TryShoot()
        {
            return _gun?.TryShoot() ?? false;
        }

        public void SelectGun(int id)
        {
            if(_gun != null)
            {
                Destroy(_gun.gameObject);
            }

            var gunData =  _gunData.getData(id);
            _gun = Instantiate(gunData.Prefab, _gunParent);
            _gun.Initialize(gunData);
        }
    }
}
