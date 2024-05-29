using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField] private float TotalHp=10;

    private float currentHp;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void RecieveDamage(float damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
