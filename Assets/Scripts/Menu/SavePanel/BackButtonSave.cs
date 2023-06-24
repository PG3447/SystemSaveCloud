using UnityEngine;

public class BackButtonSave : MonoBehaviour
{
    public void Back() {
        SavePanelManager.instance.DeactivePanelSave();
        MainPanelManager.instance.ActivePanelMain();
    }
}
