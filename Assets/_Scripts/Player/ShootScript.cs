using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootScript : MonoBehaviour, IObserver
{
    [SerializeField] private ProjectileScript _projectile;

    private PlayerInput _playerInput;

    [SerializeField] private Transform _shootPoint;

    [SerializeField] private float _timeBetweenShots=1;

    [SerializeField] private bool _canShoot=true;

    private AudioSource _source;

    [SerializeField] private AudioClip _shootSfx;

    [SerializeField] private GameObject _effect;

    [SerializeField] private float _additionalDamage;
    [SerializeField] private float _additionalProjectileSpeed;
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();

        _source = GetComponent<AudioSource>();
    }
    

    private void Start()
    {
        _playerInput.actions["Fire"].performed += Shoot;

        TargetBonusManager.instance.AddObserver(this);
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
           ProjectileScript projectile= Instantiate(_projectile, _shootPoint.position, _shootPoint.rotation);

            projectile.UpgradeDamage(_additionalDamage);

            projectile.UpgradeSpeed(_additionalProjectileSpeed);

            Instantiate(_effect, _shootPoint.position, _shootPoint.rotation);
            _canShoot = false;
            StartCoroutine(Reload());
            _source.PlayOneShot(_shootSfx);
        }

    }

    public void Observe(float damage, float speed, float time)
    {
        _additionalDamage = damage;

        _additionalProjectileSpeed = speed;
    }
}
