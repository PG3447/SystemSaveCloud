using UnityEngine;

public class BackButtonLoad : MonoBehaviour
{
    public void Back()
    {
        LoadPanelManager.instance.DeactivePanelLoad();
        MainPanelManager.instance.ActivePanelMain();
    }
}
