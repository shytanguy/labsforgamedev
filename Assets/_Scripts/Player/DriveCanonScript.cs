using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DriveCanonScript : MonoBehaviour
{
    private PlayerInput _playerInput;

    private Rigidbody _playerRigidBody;

    [SerializeField] private float _speed=5;


    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();

        _playerRigidBody = GetComponent<Rigidbody>();
    }
   
    private void FixedUpdate()
    {
        Vector2 inputVector = _playerInput.actions["Move"].ReadValue<Vector2>();

        float velocityY = _playerRigidBody.velocity.y;

        _playerRigidBody.velocity = _speed * transform.TransformDirection(new Vector3(inputVector.x, 0, inputVector.y));

        _playerRigidBody.velocity = new Vector3(_playerRigidBody.velocity.x, velocityY, _playerRigidBody.velocity.z);

    }

   
   
}
