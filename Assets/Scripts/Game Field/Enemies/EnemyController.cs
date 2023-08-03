using RunShooter.GameProccess;
using RunShooter.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RunShooter.Character
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyController : DefaultCharacterController
    {
        private Transform _playerTransform;
        private NavMeshAgent _navMeshAgent;
        private const float DESTROY_TIME = 2f;

        public void Init(PlayerObject playerObject)
        {
            _playerTransform = playerObject.transform;
            _navMeshAgent = GetComponent<NavMeshAgent>();

            base.Init();
        }

        protected override void CheckMovement()
        {
            if (GetDistanceToPlayer() <= _navMeshAgent.stoppingDistance) 
            {
                _characterView.ShowMovement(Vector3.zero);
                return;
            }

            _navMeshAgent.destination = _playerTransform.position;

            Vector2 movementAxis = GetForwardToPlayer();
            Vector3 forward = transform.forward - Vector3.forward;
            Vector2 resultDirecion = Vector2.Reflect(movementAxis, new Vector2(forward.x, forward.z));

            _characterView.ShowMovement(resultDirecion);
        }

        protected override void CheckRotation()
        {
            _characterMovement.Rotate(GetForwardToPlayer());
        }

        protected override void HandleDeath()
        {
            _navMeshAgent.isStopped = true;
            base.HandleDeath();
        }

        protected override void OnDead()
        {
            EventSystem.Broadcast(new GameFieldEvent(GameFieldEvent.ON_ENEMY_DEAD));
            StartCoroutine(DestroyRoutine());
        }

        private IEnumerator DestroyRoutine()
        {
            yield return new WaitForSeconds(DESTROY_TIME);
            Destroy(this.gameObject);
        }

        private Vector2 GetForwardToPlayer()
        {
            Vector3 directionToPlayer = (_playerTransform.position - transform.position).normalized;
            return new Vector2(directionToPlayer.x, directionToPlayer.z);
        }

        private float GetDistanceToPlayer() => Vector3.Distance(transform.position, _playerTransform.transform.position);
    }
}
