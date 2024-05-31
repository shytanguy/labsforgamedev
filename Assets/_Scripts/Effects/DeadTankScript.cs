using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTankScript : MonoBehaviour
{
    [SerializeField] private Rigidbody _head;

    [SerializeField] private float _force;
    void Start()
    {
        _head.AddForce(_force * Vector3.up, ForceMode.Impulse);   
    }

    
}
