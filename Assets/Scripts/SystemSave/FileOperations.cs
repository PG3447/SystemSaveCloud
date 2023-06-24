using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
public class FileOperations
{   
    private string DataJSON;
    private string PathDir;
    private string FileName;
    private string AllPath;

    public FileOperations(string pathdir, string fileName)
    {
        PathDir = pathdir;
        FileName = fileName;
    }

    public void Save(GameData gameDataSave) {

        AllPath = Path.Combine(PathDir, FileName);
        try
        {

            if (!Directory.Exists(PathDir))
            {
                Directory.CreateDirectory(PathDir);
            }


            if (FormatToggle.instance.ReadFormat())
            {
                FileStream StreamBin = new FileStream(AllPath, FileMode.Create);
                BinaryFormatter converter = new BinaryFormatter();

                

                converter.Serialize(StreamBin, gameDataSave);
                
                StreamBin.Close();
            }
            else
            {
                DataJSON = JsonUtility.ToJson(gameDataSave, true);

                using (StreamWriter StreamJSON = new StreamWriter(AllPath, false))
                {
                    StreamJSON.Write(DataJSON);
                }

            }

        }
        catch (Exception e) 
        {
            Debug.LogError("Error with file: " + AllPath + "\n" + e);
        }


    }
    public GameData Load()
    {
        AllPath = Path.Combine(PathDir, FileName);
        GameData gameDataLoad = null;

        if (File.Exists(AllPath))
        {
            try
            {

                if (Path.GetExtension(AllPath) == ".json")
                {
                    DataJSON = "";

                    using (StreamReader StreamJSON = new StreamReader(AllPath))
                    {
                        DataJSON = StreamJSON.ReadToEnd();
                    }

                    gameDataLoad = JsonUtility.FromJson<GameData>(DataJSON);
                } 
                else if (Path.GetExtension(AllPath) == ".bin")
                {
                    FileStream StreamBin = new FileStream(AllPath, FileMode.Open);
                    BinaryFormatter convertere = new BinaryFormatter();

                    gameDataLoad = (GameData)convertere.Deserialize(StreamBin);

                    StreamBin.Close();
                }

            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
        return gameDataLoad;
    }


    public List<string> SearchFileSave() {
        if (Directory.Exists(PathDir))
        {
            IEnumerable<string> files = Directory.GetFiles(PathDir);
            return new List<string>(files);
        }
        return null;
    }
}

