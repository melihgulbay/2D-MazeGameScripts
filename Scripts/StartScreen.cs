using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        Debug.Log("Play button clicked!"); // Debug log message
        SceneManager.LoadScene("SampleScene");
    }
}
