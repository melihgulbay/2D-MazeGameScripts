using UnityEngine;
using UnityEngine.UI;

public class ResolutionChanger2 : MonoBehaviour
{
    public Button resolutionButton;

    void Start()
    {
        resolutionButton.onClick.AddListener(ChangeResolution);
    }

    void ChangeResolution()
    {
        Screen.SetResolution(1280, 720, Screen.fullScreen);
        Debug.Log("Resolution changed to 1280x720");
    }
}
