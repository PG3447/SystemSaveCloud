using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public static PauseButton instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    public void PauseGame() {
        Time.timeScale = 0f;
        MenuManager.instance.ActivePanel();
        this.transform.gameObject.SetActive(false);
    }

    public void ActivePauseButton() {
        this.transform.gameObject.SetActive(true);
    }
}
