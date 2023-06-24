using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            this.gameObject.SetActive(false);
        }
    }

    public void ActivePanel() {
        this.gameObject.SetActive(true);
    }

    public void DeactivePanel() {
        this.gameObject.SetActive(false);
    }
}
