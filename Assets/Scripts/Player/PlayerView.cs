using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string X_AXIS = "x";
    private const string Y_AXIS = "y";

    public void Move(Vector2 axis)
    {
        _animator.SetFloat(X_AXIS, axis.x);
        _animator.SetFloat(Y_AXIS, axis.y);
    }
}
