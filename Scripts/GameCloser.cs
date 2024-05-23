using UnityEngine;

public class GameCloser : MonoBehaviour
{
    // Function to close the game
    public void CloseGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
