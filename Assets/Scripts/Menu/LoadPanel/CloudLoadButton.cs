using UnityEngine;

public class CloudLoadButton : MonoBehaviour
{
    public static CloudLoadButton instance;

    private bool ButtonActive;
    private async void Awake()
    {
        if (instance == null)
        {
            instance = this;
            ButtonActive = await SaveOperation.CheckExistSaveOnCloud();
            this.gameObject.SetActive(ButtonActive);
        }
    }

    private async void Update() {
        ButtonActive = await SaveOperation.CheckExistSaveOnCloud();
        this.gameObject.SetActive(ButtonActive);
    }

    public void CloudLoad()
    {
        ManagerSave.instance.LoadGameCloud();
        MenuManager.instance.DeactivePanel();
        LoadPanelManager.instance.DeactivePanelLoad();
        MainPanelManager.instance.ActivePanelMain();
        PauseButton.instance.ActivePauseButton();
        Time.timeScale = 1.0f;
    }

    public async void ActiveButton()
    {
        ButtonActive = await SaveOperation.CheckExistSaveOnCloud();
        this.gameObject.SetActive(ButtonActive);
    }
    
}
