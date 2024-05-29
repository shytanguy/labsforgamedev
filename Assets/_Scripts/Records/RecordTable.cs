using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecordTable : MonoBehaviour
{
    [SerializeField] private Transform _groupParent;

    [SerializeField] private TextMeshProUGUI _prefab;

    private void Start()
    {
        GameManager.instance.GameLost += ShowTable;

        RecordSerializer.LoadData();

    }
    private void OnDisable()
    {
        GameManager.instance.GameLost -= ShowTable;
    }
    private void ShowTable(float newTime)
    {
        _groupParent.parent.gameObject.SetActive(true);

        Instantiate(_prefab, _groupParent).text = "your time: " + newTime.ToString("0.0");

        RecordSerializer.PlayerRecords.Sort();

        foreach(int record in RecordSerializer.PlayerRecords)
        {
            Instantiate(_prefab, _groupParent).text = "previous time: " + newTime.ToString("0.0");

        }

        RecordSerializer.SaveData(newTime);
    }
}
