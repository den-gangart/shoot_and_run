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
        [SerializeField] private float _lifeTime;
        private Animator _animator;
        private WaitForSeconds _waitForDestroy;

        private readonly int animTriggerPickUp = Animator.StringToHash("PickUp");
        private readonly int animTriggerHide = Animator.StringToHash("Hide");

        private void Start()
        {
            _waitForDestroy = new WaitForSeconds(_lifeTime);
            _animator = GetComponent<Animator>();

            StartCoroutine(HideObjectRoutine());

            OnStart();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out PlayerObject playerObject))
            {
                OnPick(playerObject.transform);

                _animator.SetTrigger(animTriggerPickUp);
            }
        }

        private IEnumerator HideObjectRoutine()
        {
            yield return _waitForDestroy;

            _animator.SetTrigger(animTriggerHide);

            enabled = false;
        }

        protected virtual void OnStart() { }
        protected virtual void OnPick(Transform target) { }

        public void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}
