
using System;
using UnityEngine;

[System.Serializable]
public class TargetFlyweight
{
    public Transform Target { get; private set; }
    public float Speed { get; private set; }

    public TargetFlyweight(Transform target, float speed)
    {
        Target = target;
        Speed = speed;
    }
}