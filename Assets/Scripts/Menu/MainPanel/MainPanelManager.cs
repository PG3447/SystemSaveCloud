using UnityEngine;

public class MainPanelManager : MonoBehaviour
{
    public static MainPanelManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ActivePanelMain()
    {
        this.transform.gameObject.SetActive(true);
    }

    public void DeactivePanelMain()
    {
        this.transform.gameObject.SetActive(false);
    }
}
