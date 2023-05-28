using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunShooter.Player;

namespace RunShooter.GameProccess
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Animator))]
    public class BasePickedItem : MonoBehaviour
    {
        private Animator _animator;
        private readonly int animTriggerHide = Animator.StringToHash("Hide");

        private void Start()
        {
            _animator = GetComponent<Animator>();
            OnStart();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out PlayerObject playerObject))
            {
                OnPick(playerObject.transform);
                _animator.SetTrigger(animTriggerHide);
            }
        }

        protected virtual void OnStart() { }
        protected virtual void OnPick(Transform target) { }

        public void DestroyItem()
        {
            Destroy(this.gameObject);
        }
    }
}
