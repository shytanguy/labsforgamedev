using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyweightFactory : MonoBehaviour
{
   
   
    [SerializeField] private Transform _Target;
    private void Awake()
    {
        TargetScript.flyweight = new TargetFlyweight(_Target);
    }
}
