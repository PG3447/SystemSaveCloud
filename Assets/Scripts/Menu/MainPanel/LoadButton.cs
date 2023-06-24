using UnityEngine;

public class LoadButton : MonoBehaviour
{
    public void Load() {
        LoadPanelManager.instance.ActivePanelLoad();
        MainPanelManager.instance.DeactivePanelMain();
        ContentLoad.instance.ActivationLoadSearch();
    }
}
