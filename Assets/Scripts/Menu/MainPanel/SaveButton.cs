using UnityEngine;

public class SaveButton : MonoBehaviour
{
    public void Save() {
        SavePanelManager.instance.ActivePanelSave();
        MainPanelManager.instance.DeactivePanelMain();
        ContentSave.instance.ActivationSaveSearch();
    }
}
