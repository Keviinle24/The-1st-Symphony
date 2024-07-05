using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicalPlat : MonoBehaviour
{

    [SerializeField] private AudioSource[] audioplayers;

    private bool isAudioPlaying = false;

    public void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player") && audioplayers != null && audioplayers.Length > 0)
    {
        //check if the audio is not already playing
        if (!isAudioPlaying)
        {
            isAudioPlaying = true;
            
            audioplayers[0].Play();
            
            StartCoroutine(WaitForAudioFinish(audioplayers[0]));
        }
    }
}

private IEnumerator WaitForAudioFinish(AudioSource audioSource)
{
    yield return new WaitWhile(() => audioSource.isPlaying);
    
    isAudioPlaying = false;
}
}