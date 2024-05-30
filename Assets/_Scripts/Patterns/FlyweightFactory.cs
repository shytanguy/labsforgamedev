using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyweightFactory : MonoBehaviour
{
   
    [SerializeField] private float _Speed;

    [SerializeField] private Transform _Target;
    private void Awake()
    {
       Enemy.flyweight = new TargetFlyweight(_Target, _Speed);
    }
}
