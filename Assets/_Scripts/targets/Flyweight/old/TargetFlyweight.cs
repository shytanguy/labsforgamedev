
using System;
using UnityEngine;

[System.Serializable]
public class TargetFlyweight
{
    public Transform Target { get; private set; }


    public TargetFlyweight(Transform target)
    {
        Target = target;

    }
}