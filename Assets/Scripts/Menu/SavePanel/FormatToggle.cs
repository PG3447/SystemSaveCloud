using UnityEngine;
using UnityEngine.UI;

public class FormatToggle : MonoBehaviour
{
    public static FormatToggle instance;
    public bool FormatBinary;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Toggle format = this.GetComponent<Toggle>();

            format.onValueChanged.AddListener(delegate { ReadToggle(format); });
        }
    }

    void ReadToggle(Toggle change) {
        FormatBinary = change.isOn;
    }


    public bool ReadFormat() {
        return FormatBinary;
    }
}
