using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[System.Serializable]
public class ListWrap
{
    public List<float> List;

    public ListWrap(List<float> list)
    {
        List = list;
    }
}
public class RecordSerializer 
{
    private static string filePath = Directory.GetCurrentDirectory() + "/records.json";
    public static List<float> PlayerRecords = new List<float>();
    public static void SaveData(float record)
    {
        PlayerRecords.Add(record);
        ListWrap wrapper = new ListWrap(PlayerRecords);
        string json = JsonUtility.ToJson(wrapper);
        File.WriteAllTextAsync(filePath, json);
    }

    public static void LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            ListWrap wrapper = JsonUtility.FromJson<ListWrap>(json);
            PlayerRecords = wrapper.List;
        }
        else
        {
            File.Create(filePath);
        }

    }
  
}
