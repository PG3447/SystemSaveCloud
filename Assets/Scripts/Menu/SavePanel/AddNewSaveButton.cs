using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AddNewSaveButton : MonoBehaviour
{
    private List<string> files;
    private int CountSave;
    private string pathdir;
    private string namefile;
    private string extension;
    public void NewSaveGame()
    {
        pathdir = "";
        namefile = "";
        extension = "";
        

        pathdir = ManagerSave.instance.ReadPathDir();

        files = ManagerSave.instance.SearchFileSave();

        CountSave = 1;

        if (files != null)
        {
            if (files.Count != 0)
            {
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) == ".json" || Path.GetExtension(file) == ".bin")
                    {
                        CountSave++;
                    }
                }
            }

        }

        if (FormatToggle.instance.FormatBinary)
        {
            extension = ".bin";
        }
        else {
            extension = ".json";
        }

        do
        {
            namefile = "Save" + CountSave + extension;
            CountSave ++;
        } while (File.Exists(Path.Combine(pathdir, namefile)));

        ManagerSave.instance.UpdatePath(pathdir, namefile);
        ManagerSave.instance.SaveGame(false);
        MenuManager.instance.DeactivePanel();
        SavePanelManager.instance.DeactivePanelSave();
        MainPanelManager.instance.ActivePanelMain();
        PauseButton.instance.ActivePauseButton();
        Time.timeScale = 1.0f;

    }
}
