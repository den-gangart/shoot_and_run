using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Character
{
    public class TestGunSelection : MonoBehaviour
    {
        [SerializeField] private int gunid;
        private CharacterGun _characterGun;

        private void Start()
        {
            _characterGun = GetComponent<CharacterGun>();
        }

        public void Select()
        {
            _characterGun.SelectGun(gunid);
        }
    }
}
