using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    [SerializeField] private float _Time = 1;

    private IEnumerator DestroyOnTime()
    {
        yield return new WaitForSeconds(_Time);
        Destroy(gameObject);
    }
    private void Start()
    {
        StartCoroutine(DestroyOnTime());
    }
}
