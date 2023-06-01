using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunShooter.Guns;
using Unity.Burst.CompilerServices;

namespace RunShooter.Character
{
    [RequireComponent(typeof(ICharacter))]
    public class CharacterGun : MonoBehaviour
    {
        [SerializeField] private GunData _gunData;
        [SerializeField] private Transform _aimStartPoint;

        private Transform _gunParent;
        private BaseGun _gun;
        private CharacterType _characterType;

        public void Initialize(Transform gunParent)
        {
            _gunParent = gunParent;
            _characterType = GetComponent<ICharacter>().CharacterType;
        }

        public bool TryShoot()
        {
            if (_gun == null || _gun.OnReolad)
            {
                return false;
            }

            if(isTargetDetected(out IDamagable target))
            {
                return _gun.TryShoot(target);
            }

            return false;
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

        private bool isTargetDetected(out IDamagable target)
        {
            RaycastHit hit;
            target = null;

            if (Physics.Raycast(_aimStartPoint.position, transform.forward, out hit, _gun.Params.maxDistance))
            {
                if (hit.transform.TryGetComponent(out IDamagable damagable))
                {
                    bool hasSameType = isTargetSameCharacter(hit.transform);
                    target = hasSameType ? null : damagable;
                    return !hasSameType;
                }
            }

            Debug.DrawRay(_aimStartPoint.position + Vector3.up, transform.forward);

            return false;
        }

        private bool isTargetSameCharacter(Transform target)
        {
            if(target.TryGetComponent(out ICharacter character))
            {
                return character.CharacterType == _characterType;
            }

            return false;
        }
    }
}
