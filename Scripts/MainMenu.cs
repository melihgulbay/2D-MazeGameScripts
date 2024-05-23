using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void MainReturn()
    {
        Debug.Log("Play button clicked!"); // Debug log message
        SceneManager.LoadScene("startscene");
    }
}
