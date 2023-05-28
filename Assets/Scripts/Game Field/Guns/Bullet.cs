using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Guns
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent (typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _explosionForce;
        [SerializeField] private float _radius;
        [SerializeField] private float _speed;
        [SerializeField] private GameObject _prefabFX;

        private Vector3 _direction;
        private float _damage;
        private Rigidbody _rigidBody;

        public void Initialize(float damage, Vector3 direction)
        {
            _direction = direction;
            _damage = damage;
        }

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _rigidBody.MovePosition(transform.position + _direction * _speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, _radius, transform.forward);
             
            foreach (var hit in hits)
            {
                var hitTransform = hit.transform;
                if (hitTransform.TryGetComponent(out IDamagable damagable))
                {
                    float distance = Vector3.Distance(transform.position, hitTransform.position);
                    float damage = _damage -_damage * (distance / _radius);
                    damagable.TakeDamage(damage);
                    hitTransform.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _radius);
                }
            }

            Instantiate(_prefabFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
