using RunShooter.Character;
using RunShooter.Guns;
using RunShooter.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RunShooter.GameProccess
{
    public class GunPickedItem : BasePickedItem
    {
        [SerializeField] private GunData _gunData;
        [SerializeField] private List<Transform> _gunPivots;
        [SerializeField] private int _selectedGunId;

        public void Initialize(int id)
        {
            _selectedGunId = id;
        }

        protected override void OnStart()
        {
            var gunPrefab = _gunData.getData(_selectedGunId).Prefab;
            var gunObject = Instantiate(gunPrefab, _gunPivots[_selectedGunId]);
            gunObject.transform.localPosition = Vector3.zero;
            gunObject.transform.localRotation =  Quaternion.identity;
        }

        protected override void OnPick(Transform target)
        {
            target.GetComponent<DefaultCharacterController>().SelectGun(_selectedGunId);
        }
    }
}
