using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource;
    public float skipDuration = 0f; 

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlaySound()
    {
        if(skipDuration > 0f){
            SkipForward();
            audioSource.Play();
        }
        else{

        
        audioSource.Play();
    }
    }

    public void SkipForward()
    {
        SkipAudio(skipDuration);
    }

    public void SkipBackward()
    {
        SkipAudio(-skipDuration);
    }

    private void SkipAudio(float secondsToSkip)
    {
        float newTime = audioSource.time + secondsToSkip;

        newTime = Mathf.Clamp(newTime, 0f, audioSource.clip.length);

        audioSource.time = newTime;
    }
}
