using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LevelLoader : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RenderTexture renderTexture;
    public string nextLevelName; // New variable to store the next level name

    private bool hasPlayerCollided = false;

    void Start()
    {
        videoPlayer.targetTexture = renderTexture;
        videoPlayer.Stop();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasPlayerCollided)
        {
            hasPlayerCollided = true;
            videoPlayer.Play();
            Invoke(nameof(LoadNextScene), (float)videoPlayer.clip.length);
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextLevelName); // Load the level specified in nextLevelName
    }

    void OnDisable()
    {
        ResetVideoPlayer();
    }

    void OnDestroy()
    {
        ResetVideoPlayer();
    }

    void ResetVideoPlayer()
    {
        videoPlayer.Stop();
        videoPlayer.targetTexture = null;
        RenderTexture.active = null;
        RenderTexture.ReleaseTemporary(renderTexture);
    }
}
