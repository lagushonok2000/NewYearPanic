using System;
using System.IO;
using UnityEngine;

public static class SaveGame
{
    public static DataClass Data;
    private static string _path = Application.dataPath + "/Saves.json";

    public static void SaveData()
    {
        var json = JsonUtility.ToJson(Data);
        File.WriteAllText(_path, json);
    }

    public static void LoadData()
    {
        if (!File.Exists(_path))
        {
            Data = new DataClass();
            SaveData();
            return;
        }
        string data = File.ReadAllText(_path);
        Data = JsonUtility.FromJson<DataClass>(data);
    }
}

[Serializable]
public class DataClass
{
    public int CurrentLevel = 0;
    public int CurrentIndexScene = 0;
}