using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _Spawners;

    [SerializeField] private Health[] _prefabToSpawn;

    [SerializeField] private float _spawnCoolDown;
    private void SpawnTarget()
    {
     Instantiate(_prefabToSpawn[Random.Range(0, _prefabToSpawn.Length)], _Spawners[Random.Range(0, _Spawners.Length)].position, Quaternion.identity);


    }
    private void Start()
    {
        InvokeRepeating(nameof(SpawnTarget), 3, _spawnCoolDown);
    }

}
