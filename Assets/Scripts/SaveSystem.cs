using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem{
    
    public static void SaveGame(string Map, Money money, AdvertiseController adController) {
        BinaryFormatter formatter = new BinaryFormatter();

        string path;

        switch (Map)
        {
            case "1":
                path = Application.persistentDataPath + "/GameDataMap1.lol";
                setStreamAndSave(path, money, adController, formatter);
                break;
            case "2":
                path = Application.persistentDataPath + "/GameDataMap2.lol";
                setStreamAndSave(path, money, adController, formatter);
                break;
            case "3":
                path = Application.persistentDataPath + "/GameDataMap3.lol";
                setStreamAndSave(path, money, adController, formatter);
                break;
        }
    }

    public static GameData LoadGame(string Map)
    {
        string path;

        switch (Map)
        {
            case "1":
                path = Application.persistentDataPath + "/GameDataMap1.lol";
                return setStreamAndLoad(path);
            case "2":
                path = Application.persistentDataPath + "/GameDataMap2.lol";
                return setStreamAndLoad(path);
            case "3":
                path = Application.persistentDataPath + "/GameDataMap3.lol";
                return setStreamAndLoad(path);
            default: return null;
        }
    }

    public static CityData LoadCityData()
    {
        string path = Application.persistentDataPath + "/CityData.lol"; ;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CityData data = formatter.Deserialize(stream) as CityData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Load File not found in path: " + path);
            return null;
        }
    }

    public static void DeleteSave()
    {
        string path1;
        string path2 = Application.persistentDataPath + "/CityData.lol"; ;
        SetPathAndDelete(path2);
        path1 = Application.persistentDataPath + "/GameDataMap1.lol";
        SetPathAndDelete(path1);
        path1 = Application.persistentDataPath + "/GameDataMap2.lol";
        SetPathAndDelete(path1);
        path1 = Application.persistentDataPath + "/GameDataMap3.lol";
        SetPathAndDelete(path1);
    }

    private static void setStreamAndSave(string path, Money money, AdvertiseController adController, BinaryFormatter formatter)
    {
        FileStream stream1 = new FileStream(path, FileMode.Create);
        GameData data = new GameData(money, adController);
        formatter.Serialize(stream1, data);
        stream1.Close();

        FileStream stream2 = new FileStream(Application.persistentDataPath + "/CityData.lol", FileMode.Create);
        CityData CityData = new CityData();
        formatter.Serialize(stream2, CityData);
        stream2.Close();
    }


    private static GameData setStreamAndLoad(string path)
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Load File not found in path: " + path);
            return null;
        }
    }

    private static void SetPathAndDelete(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            Debug.LogError("Delete File not found in path: " + path);
        }
    }
}
