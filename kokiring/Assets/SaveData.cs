using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class SaveData : MonoBehaviour
{

    public void Save<T>(T objectToSave, string key) {
        string path = Application.persistentDataPath + "/Draws/";
        Directory.CreateDirectory(path);
        BinaryFormatter formatter = new BinaryFormatter();

        using ( FileStream fs = new FileStream(path + key + ".pdf", FileMode.Create))
        {            
            formatter.Serialize(fs, objectToSave);
        }

    }
    public T LoadKey<T>(string key)
    {
        T returnValue = default(T);

        if (ExistFile(key)){
            string path = Application.persistentDataPath + "/Draws/";
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(path + key + ".pdf", FileMode.Open))
            {
                returnValue = (T)formatter.Deserialize(fs);
            }
        }

        return returnValue;
    }


    public static bool ExistFile(string key) {
        return (File.Exists(Application.persistentDataPath + "/Draws/" + key + ".pdf"));
    }


    public static void DeleteAll() {
        string path = Application.persistentDataPath + "/Draws/";
        DirectoryInfo directory = new DirectoryInfo(path);
        directory.Delete();
        Directory.CreateDirectory(path);
    }

}