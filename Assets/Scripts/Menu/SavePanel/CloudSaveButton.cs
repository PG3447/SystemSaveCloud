using UnityEngine;

public class CloudSaveButton : MonoBehaviour
{
    public void CloudSave() {
        ManagerSave.instance.SaveGame(true);
        LoadPanelManager.instance.ActivePanelLoad();
        LoadPanelManager.instance.DeactivePanelLoad();
        CloudLoadButton.instance.ActiveButton();
        DeleteCloudSaveButton.instance.ActiveButton();
        MenuManager.instance.DeactivePanel();
        SavePanelManager.instance.DeactivePanelSave();
        MainPanelManager.instance.ActivePanelMain();
        PauseButton.instance.ActivePauseButton();
        Time.timeScale = 1.0f;
    }
}
