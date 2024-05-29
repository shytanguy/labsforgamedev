using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;

    private PlayerInput _playerInput;

    [SerializeField] private Transform _shootPoint;

    [SerializeField] private float _timeBetweenShots=1;

    [SerializeField] private bool _canShoot=true;

    private AudioSource _source;

    [SerializeField] private AudioClip _shootSfx;

    [SerializeField] private GameObject _effect;
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();

        _source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _playerInput.actions["Fire"].performed += Shoot;
    }
    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(_timeBetweenShots);
        _canShoot = true;
    }
    private void OnDisable()
    {
        _playerInput.actions["Fire"].performed -= Shoot;
    }
    private void Shoot(InputAction.CallbackContext context)
    {   
        if (_canShoot)
        {
            Instantiate(_projectile, _shootPoint.position, _shootPoint.rotation);
            Instantiate(_effect, _shootPoint.position, _shootPoint.rotation);
            _canShoot = false;
            StartCoroutine(Reload());
            _source.PlayOneShot(_shootSfx);
        }

    }
}
