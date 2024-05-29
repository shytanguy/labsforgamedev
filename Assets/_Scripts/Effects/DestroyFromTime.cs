using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFromTime : MonoBehaviour
{
    [SerializeField] private float _timeAlive;

    private void Start()
    {
        Invoke(nameof(DeleteObject), _timeAlive);
    }

    private void DeleteObject()
    {
        Destroy(gameObject);
    }
}
