using UnityEngine;

public class ReturnButton : MonoBehaviour
{
    public void ReturnToGame() {
        Time.timeScale = 1f;
        PauseButton.instance.ActivePauseButton();
        MenuManager.instance.DeactivePanel();
    }
}
