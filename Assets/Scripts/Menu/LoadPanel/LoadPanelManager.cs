using UnityEngine;

public class LoadPanelManager : MonoBehaviour
{
    public static LoadPanelManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            this.transform.gameObject.SetActive(false);
        }
    }

    public void ActivePanelLoad()
    {
        this.transform.gameObject.SetActive(true);
    }

    public void DeactivePanelLoad()
    {
        this.transform.gameObject.SetActive(false);
    }

}
