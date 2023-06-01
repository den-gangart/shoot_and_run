using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Character
{
    [RequireComponent(typeof(DefaultCharacterController))]
    public class CharacterGunSelector : MonoBehaviour
    {
        [SerializeField] private int gunid;
        private DefaultCharacterController _characterController;

        private void Start()
        {
            _characterController = GetComponent<DefaultCharacterController>();
            Select();
        }

        public void Select()
        {
            _characterController.SelectGun(gunid);
        }
    }
}
