using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] private float _speed;

    [SerializeField] private Rigidbody _rigidBody;

    [SerializeField] private Transform _head;

    [SerializeField] private PlayerInput _controls;

    private float _yRotation;

    [SerializeField] private GameObject _pea;

    private void OnEnable()
    {
        _controls.actions["Attack"].performed += Shoot;
    }
    private void OnDisable()
    {
        _controls.actions["Attack"].performed -= Shoot;
    }

    void FixedUpdate()
    {
        Vector3 direction = _controls.actions["Move"].ReadValue<Vector2>();

        _rigidBody.velocity =_speed* transform.TransformDirection( new Vector3(direction.x, 0, direction.y));

        Vector2 rotation = _controls.actions["Rotate"].ReadValue<Vector2>();

        _yRotation += -rotation.y;

        _yRotation = Mathf.Clamp(_yRotation, -90f, 90f);

        _head.localRotation = Quaternion.Euler(_yRotation, 0, _head.localRotation.eulerAngles.z);
      
        transform.Rotate(0, rotation.x, 0);
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        Instantiate(_pea, _head.position, _head.rotation);
    }

   
    
}
