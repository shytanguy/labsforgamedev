using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Records 
{
    private static string filePath = Directory.GetCurrentDirectory() + "/records.json";

    public static List<int> records = new List<int>();
    public static void Save(int record)
    {
        records.Add(record);
        Wrapper<int> wrapper = new Wrapper<int>(records);
        string json = JsonUtility.ToJson(wrapper);
File.WriteAllText(filePath, json);

    }

    public static void Load()
    {      if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Wrapper<int> wrapper = JsonUtility.FromJson<Wrapper<int>>(json);
            if (wrapper!=null)
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
    public List<T> intList;

    public Wrapper(List<T> list)
    {
        intList = list;
    }
}