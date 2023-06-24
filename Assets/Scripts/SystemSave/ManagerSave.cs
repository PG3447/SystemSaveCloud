using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ManagerSave : MonoBehaviour
{
    public static ManagerSave instance;
    
    private GameData gameData;
    private List<IManagerSave> AllIManagerSave;
    private FileOperations dataOperations;
    private string dirpath;
    private string filename;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
            dirpath = Path.Combine(Application.dataPath, "Save");
            filename = "Save1.json";
        }
    }

    private void Start()
    {
        UpdatePath(dirpath, filename);
        AllIManagerSave = FindAllIManagerSave();
        NewGame();
    }

    public void NewGame() {
        gameData = new GameData();

        gameData.DeafultSetting();

        foreach (IManagerSave Gamedata in AllIManagerSave) {

            Gamedata.DataLoad(gameData);
        }
    }

    public void LoadGame() {
        gameData = dataOperations.Load();


        foreach (IManagerSave Gamedata in AllIManagerSave)
        {

            Gamedata.DataLoad(gameData);
        }
    }

    public void SaveGame(bool cloud)
    {
        gameData.SpheresPositions.Clear();
        gameData.SpheresForces.Clear();
        
        foreach (IManagerSave Gamedata in AllIManagerSave)
        {
            
            Gamedata.DataSave(ref gameData);
        }

        if (cloud)
        {
            SaveOperation.SaveGameToCloud(gameData);
        }
        else
        {
            dataOperations.Save(gameData);
        }
    }

    public async void LoadGameCloud()
    {
        gameData = await SaveOperation.LoadGameOnCloud();

        if (gameData == null) {
            NewGame();
        }

        foreach (IManagerSave Gamedata in AllIManagerSave)
        {

            Gamedata.DataLoad(gameData);
        }
    }

    public void UpdatePath(string dir, string filename)
    {
        dataOperations = new FileOperations(dir, filename);
    }

    public string ReadPathDir() {
        return dirpath;
    }

    public List<string> SearchFileSave() {
        return dataOperations.SearchFileSave();
    }


    private List<IManagerSave> FindAllIManagerSave() {
        IEnumerable<IManagerSave> IManagerSave = FindObjectsOfType<MonoBehaviour>().OfType<IManagerSave>();
        return new List<IManagerSave>(IManagerSave);
    }
}
