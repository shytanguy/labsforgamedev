using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyweightFactory : MonoBehaviour
{


    [SerializeField] private FlyweightSO so;
    private void Awake()
    {
        so.Load();
    }
}
