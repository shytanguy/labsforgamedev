using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;

    [SerializeField] private float _speed;

    [SerializeField] private Rigidbody _playerRigidbody;

    [SerializeField] private GameObject _projectilePrefab;

    [SerializeField] private Transform _shootPoint;

    [SerializeField] private Transform _spoon;

    [SerializeField] private Animator _animator;

    [SerializeField] private AudioClip clip;

    [SerializeField] private AudioSource source;

   
    void OnEnable()
    {
        _input.actions["fire"].performed += Fire;
    }
    private void OnDisable()
    {
        _input.actions["fire"].performed -= Fire;
    }
    private void Fire(InputAction.CallbackContext context)
    {
        Instantiate(_projectilePrefab, _shootPoint.position, _shootPoint.rotation);

        _animator.Play("attack");
        source.PlayOneShot(clip);
       
    }
    
    void FixedUpdate()
    {
        Vector2 input = _input.actions["move"].ReadValue<Vector2>();
        if (input != Vector2.zero)
        {
            _animator.Play("walk");
        }
        else
        {
            _animator.Play("idle");
        }
        transform.Rotate(0, input.x*5, 0);


        _playerRigidbody.velocity = transform.forward * input.y * _speed;

        _shootPoint.Rotate(_input.actions["aim"].ReadValue<float>(),0,0);
  
    }


}
