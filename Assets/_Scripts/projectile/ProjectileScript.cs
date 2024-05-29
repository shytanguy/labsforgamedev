using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private Rigidbody _rigidBody;

    [SerializeField] private float _speed;

    [SerializeField] private LayerMask _targets;

    [SerializeField] private float _damage;

    public static ShootScript shooter;

    public void UpgradeDamage(float additionalDamage)
    {
        _damage += additionalDamage;
    }
    public void UpgradeSpeed(float speedUpgrade)
    {
        _speed += speedUpgrade;
    }
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();

        _rigidBody.velocity = transform.forward * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((_targets.value & (1 << other.gameObject.layer)) > 0)
        {
          other.GetComponent<Health>().Damage(_damage);

        }
        Destroy(gameObject);
    }
}
