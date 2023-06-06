using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RunShooter.Character;

namespace RunShooter.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterMovement : MonoBehaviour, ICharacterMovement
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField, Range(0, 1)] private float _rotationDeltaSpeed;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(Vector2 axis)
        {
            Vector3 velocity = new Vector3(axis.x, 0, axis.y);
            velocity = Vector3.ClampMagnitude(velocity, 1) * Time.fixedDeltaTime * _movementSpeed;
            _rigidbody.MovePosition(transform.position + velocity);      
        }

        public void Rotate(Vector2 axis)
        {
            Vector3 velocity = new Vector3(axis.x, 0, axis.y);
            Quaternion loolRotation = Quaternion.LookRotation(velocity, Vector3.up);
            Quaternion rotation = Quaternion.Lerp(transform.rotation, loolRotation, _rotationDeltaSpeed);
            transform.rotation = rotation;
        }

        public void Kill()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.isKinematic = true;
        }
    }
}