using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class ContentLoad : MonoBehaviour
{
    public static ContentLoad instance;

    private List<string> files;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ActivationLoadSearch()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }

        Vector3 position = this.transform.localPosition;

        position.y = 0;

        transform.localPosition = position;


        files = ManagerSave.instance.SearchFileSave();

        if (files == null)
        {
            return;
        }

        foreach (string file in files)
        {
            if (Path.GetExtension(file) == ".json" || Path.GetExtension(file) == ".bin")
            {


                Button prefabButton = Resources.Load<Button>("Prefabs/Button");

                var button = Instantiate(prefabButton, transform);

                button.transform.SetParent(this.transform);

                button.name = "LoadButton";

                button.GetComponentInChildren<TextMeshProUGUI>().text = Path.GetFileNameWithoutExtension(file);
                button.GetComponent<Button>().onClick.AddListener(delegate { ButtonAction(file); });
            }
        }

    }

    void ButtonAction(string path)
    {
        string pathdir = Path.GetDirectoryName(path);
        string namefile = Path.GetFileName(path);
        ManagerSave.instance.UpdatePath(pathdir, namefile);
        ManagerSave.instance.LoadGame();
        MenuManager.instance.DeactivePanel();
        LoadPanelManager.instance.DeactivePanelLoad();
        MainPanelManager.instance.ActivePanelMain();
        PauseButton.instance.ActivePauseButton();
        Time.timeScale = 1.0f;
    }
}
