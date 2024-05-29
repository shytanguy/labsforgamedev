using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimScript : MonoBehaviour
{
    private PlayerInput _playerInput;

    [SerializeField] private Transform _canon;

    [SerializeField] private Transform _head;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        Vector2 input = _playerInput.actions["MoveCanon"].ReadValue<Vector2>();

        _canon.localRotation = Quaternion.Euler(-input.y + _canon.localRotation.eulerAngles.x, 0, 0);

        _head.Rotate(new Vector3(0, input.x, 0));
    }
}
