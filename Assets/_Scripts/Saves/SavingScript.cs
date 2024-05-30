using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SavingScript : MonoBehaviour
{
    private static string filePath = Directory.GetCurrentDirectory() + "/save.json";

    public static List<int> records = new List<int>();
    public static void Save(int record)
    {
        records.Add(record);

        Wrapper<int> wrapper = new Wrapper<int>(records);

        string json = JsonUtility.ToJson(wrapper);

        File.WriteAllText(filePath, json);


    }

    public static void Load()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Wrapper<int> wrapper = JsonUtility.FromJson<Wrapper<int>>(json);
            records = wrapper.intList;
        }
        else
        {
            File.Create(filePath);
        }

    }
    public static void AddRecord(int i)
    {
        records.Add(i);
    }
}
[System.Serializable]
public class Wrapper<T>
{
    public List<int> intList;
    public Wrapper(List<int> list)
    {
        intList = list;
    }
}