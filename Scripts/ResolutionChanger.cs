using UnityEngine;
using UnityEngine.UI;

public class ResolutionChanger : MonoBehaviour
{
    public Button resolutionButton;

    void Start()
    {
        resolutionButton.onClick.AddListener(ChangeResolution);
    }

    void ChangeResolution()
    {
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
        Debug.Log("Resolution changed to 1920x1080");
    }
}
