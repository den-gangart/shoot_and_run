using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Guns
{
    public class FXGunView : BaseGunView
    {
        [SerializeField] private GameObject _fxObject;

        protected override void OnChanged(bool isShooting)
        {
            _fxObject.SetActive(isShooting);
        }
    }
}
