using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class NextSceneForIntro : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component
    public float delayAfterVideo = 2f; // Delay in seconds after video ends before switching scenes
    public string nextSceneName; // Name of the next scene to load

    private void Start()
    {
        // Subscribe to the video player's loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // Start the coroutine to handle scene transition with delay
        StartCoroutine(WaitAndSwitchScene());
    }

    private IEnumerator WaitAndSwitchScene()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayAfterVideo);

        // Load the next scene
        SceneManager.LoadScene("StartGame");
    }
}
