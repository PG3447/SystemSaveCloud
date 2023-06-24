using UnityEngine;

public class SavePanelManager : MonoBehaviour
{
    public static SavePanelManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            this.transform.gameObject.SetActive(false);
        }
    }

    public void ActivePanelSave() {
        this.transform.gameObject.SetActive(true);
    }

    public void DeactivePanelSave()
    {
        this.transform.gameObject.SetActive(false);
    }

}
