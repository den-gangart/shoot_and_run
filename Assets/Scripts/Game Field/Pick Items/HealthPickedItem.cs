using RunShooter.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.GameProccess
{
    public class HealthPickedItem : BasePickedItem
    {
        [SerializeField] private float _healthAddAmount = 20f;

        protected override void OnPick(Transform target)
        {
            target.GetComponent<DefaultCharacterController>().Health.Add(_healthAddAmount);
        }
    }
}
