using UnityEngine;

public class NewGameButton : MonoBehaviour
{
    public void NewGame() {
        Time.timeScale = 1.0f;
        MenuManager.instance.DeactivePanel();
        PauseButton.instance.ActivePauseButton();
        ManagerSave.instance.NewGame();
    }
}
