using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Guns
{
    public class FXGunView : BaseGunView
    {
        [SerializeField] private GameObject _fxObject;
        [SerializeField] private string _soundName;

        protected override void OnChanged(bool isShooting)
        {
            if (isShooting && !string.IsNullOrEmpty(_soundName))
            {
                AudioHandler.Instance.PlayGameSound(_soundName, gameObject);
            }

            _fxObject.SetActive(isShooting);
        }
    }
}
