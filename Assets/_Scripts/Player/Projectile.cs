using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private int layer = 6;

    private Rigidbody _ball;
    void Start()
    {
        _ball = GetComponent<Rigidbody>();

        _ball.AddForce(transform.forward * _speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layer)
        {
            other.GetComponent<Enemy>().DestroyBox();
        }
        Destroy(gameObject);
    }
}
