using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject box;
    [SerializeField] private float timeForSpawn;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBox), 1, timeForSpawn);
    }
    public void SpawnBox()
    {
        Instantiate(box, transform.position, Quaternion.identity);
    }
}
