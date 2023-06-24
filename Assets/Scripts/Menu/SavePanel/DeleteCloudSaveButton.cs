using UnityEngine;

public class DeleteCloudSaveButton : MonoBehaviour
{
    public static DeleteCloudSaveButton instance;

    private bool ButtonActive;
    private async void Awake()
    {
        if (instance == null)
        {
            instance = this;
            ButtonActive = await SaveOperation.CheckExistSaveOnCloud();
            this.gameObject.SetActive(ButtonActive);
        }
    }

    public async void DeleteSaveOnCloud() {
        SaveOperation.DeleteSaveOnCloud();
        ButtonActive = await SaveOperation.CheckExistSaveOnCloud();
        this.gameObject.SetActive(ButtonActive);
    }

    public async void ActiveButton() {
        ButtonActive = await SaveOperation.CheckExistSaveOnCloud();
        this.gameObject.SetActive(ButtonActive);
    }

}
