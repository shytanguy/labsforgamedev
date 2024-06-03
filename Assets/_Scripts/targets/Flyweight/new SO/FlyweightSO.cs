using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TargetFlyweight",menuName ="target Flyweight")]
public class FlyweightSO : ScriptableObject
{
    public Transform target;

    public float Speed;

    public float Damage;

    public void Load()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
