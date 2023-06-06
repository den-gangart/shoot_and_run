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

        protected override void OnStart()
        {
            GunParameters selectedGun = _gunData.GetRandomGun();

            var gunObject = Instantiate(selectedGun.Prefab, _gunPivots[selectedGun.id]);

            gunObject.transform.localPosition = Vector3.zero;
            gunObject.transform.localRotation = Quaternion.identity;

            _selectedGunId = selectedGun.id;
        }

        protected override void OnPick(Transform target)
        {
            target.GetComponent<DefaultCharacterController>().SelectGun(_selectedGunId);
        }
    }
}
