using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class ContentSave : MonoBehaviour
{
    public static ContentSave instance;

    private List<string> files;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ActivationSaveSearch()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }

        Vector3 position = this.transform.localPosition;

        position.y = 0;

        transform.localPosition = position;

        files = ManagerSave.instance.SearchFileSave();

        if (files == null) {
            return;
        }

        foreach (string file in files)
        {
            if (Path.GetExtension(file) == ".json" || Path.GetExtension(file) == ".bin") {
                
                

                GameObject prefabButton = Resources.Load<GameObject>("Prefabs/LabelButtons");

                var LabelButtons = Instantiate(prefabButton, transform);

                LabelButtons.transform.SetParent(this.transform);

                LabelButtons.name = "LabelButtons";

                GameObject SaveButton = LabelButtons.transform.Find("SaveButton").gameObject;
                GameObject DeleteButton = LabelButtons.transform.Find("DeleteButton").gameObject;

                SaveButton.GetComponentInChildren<TextMeshProUGUI>().text = Path.GetFileNameWithoutExtension(file);
                SaveButton.GetComponent<Button>().onClick.AddListener(delegate { ButtonActionSave(file); });

                DeleteButton.GetComponent<Button>().onClick.AddListener(delegate { ButtonActionDelete(file); });

            }
        }

    }

    void ButtonActionSave(string path) {
        string extension;

        if (FormatToggle.instance.FormatBinary)
        {
            extension = ".bin";
        }
        else
        {
            extension = ".json";
        }

        string pathdir = Path.GetDirectoryName(path);
        string namefile = Path.GetFileNameWithoutExtension(path) + extension;
        ManagerSave.instance.UpdatePath(pathdir, namefile);
        ManagerSave.instance.SaveGame(false);
        MenuManager.instance.DeactivePanel();
        SavePanelManager.instance.DeactivePanelSave();
        MainPanelManager.instance.ActivePanelMain();
        PauseButton.instance.ActivePauseButton();
        Time.timeScale = 1.0f;
    }


    void ButtonActionDelete(string path)
    {
        File.Delete(path);
        ContentSave.instance.ActivationSaveSearch();
    }

}
