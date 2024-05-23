using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen2 : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        Debug.Log("Settings button clicked!"); // Debug log message
        SceneManager.LoadScene("settingscene");
    }
}
