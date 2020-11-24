using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem{
    
    public static void SaveGame(Money money) {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/GameData.lol";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(money);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGame()
    {
        string path = Application.persistentDataPath + "/GameData.lol";
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

    public static void DeleteSave()
    {
        string path = Application.persistentDataPath + "/GameData.lol";
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
