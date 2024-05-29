using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private Rigidbody _rigidBody;

    [SerializeField] private float _speed;

    [SerializeField] private LayerMask _targets;
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();

        _rigidBody.velocity = transform.forward * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((_targets.value & (1 << other.gameObject.layer)) > 0)
        {

        }
        Destroy(gameObject);
    }
}
