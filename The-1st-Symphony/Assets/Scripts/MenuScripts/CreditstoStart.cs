using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditstoStart : MonoBehaviour
{
    public float delayInSeconds = 6f;
    FadeInOut Fade;

    void Start()
    {
        Fade = FindObjectOfType<FadeInOut>();
    }
    public void StartGame()
    {
        Fade.FadeIn();
        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {
        Debug.Log("Waiting before transitioning to Start Game scene.");
        
        yield return new WaitForSeconds(delayInSeconds);
        
        Debug.Log("Back to Start");
        AudioManager.Instance.DestroyCToS();
        SceneManager.LoadScene("StartGame");
    }
}
