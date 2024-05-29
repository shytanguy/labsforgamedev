using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed=15;

    [SerializeField] private float damage=5;

    [SerializeField] private Rigidbody bulletBody;

    [SerializeField] private int targetLayer;
    void Start()
    {
        bulletBody.velocity = speed * transform.forward;
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == targetLayer)
        {
            other.GetComponent<TargetScript>().RecieveDamage(damage);
        }
        Destroy(gameObject);
    }
}
