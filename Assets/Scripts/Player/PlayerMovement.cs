using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour, ICharacterMovement
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField, Range(0, 1)] private float _rotationDeltaSpeed;

        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(Vector2 axis)
        {
            Vector3 velocity = new Vector3(axis.x, _rigidbody.velocity.y, axis.y);
            velocity = Vector3.ClampMagnitude(velocity, 1);
            velocity *= _movementSpeed;

            _rigidbody.velocity = velocity;      
        }

        public void Rotate(Vector2 axis)
        {
            Vector3 velocity = new Vector3(axis.x, 0, axis.y);
            Quaternion loolRotation = Quaternion.LookRotation(velocity, Vector3.up);
            Quaternion rotation = Quaternion.Lerp(transform.rotation, loolRotation, _rotationDeltaSpeed);
            transform.rotation = rotation;
        }
    }
}