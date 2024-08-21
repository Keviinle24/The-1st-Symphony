using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    [SerializeField] private AudioSource BG_Music;
    [SerializeField] private Sound BG_Sound;

    public bool fadein = false;
    public bool fadeout = false;
    public bool canFadeSound = true;
    public bool canSoundIn = true;

    public float CredTime;


    public float timeToFade;
    // Update is called once per frame
    void Update()
    {
        if(fadein == true)
        {
            if(canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += timeToFade * Time.deltaTime;
                if (BG_Music != null){
                BG_Music.volume -= timeToFade * Time.deltaTime; //fade in/out bg music
                } 
                if (BG_Sound != null){
                BG_Sound.volume -= timeToFade * Time.deltaTime; //fade in/out bg music
                 CredTime = BG_Sound.volume;
                if (canFadeSound){
                AudioManager.Instance.MusicVolume(BG_Sound.volume);
                }                } 
                if(canvasGroup.alpha >= 1)
                {
                    fadein = false;
                }
            }
        }
        if(fadeout == true)
        {
            if(canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= timeToFade * Time.deltaTime;
                if (BG_Music != null){
                BG_Music.volume += timeToFade * Time.deltaTime;
                }
                if (BG_Sound != null){
                BG_Sound.volume += timeToFade * Time.deltaTime; //fade in/out bg music
                if(AudioManager.Instance != null){
                if(canSoundIn){
                AudioManager.Instance.MusicVolume(BG_Sound.volume);
                }
                }
                } 
                if(canvasGroup.alpha == 0)
                {
                    fadeout = false;
                }
            }
        }
    }

    public void FadeIn()
    {
        fadein = true;
    }

    public void FadeOut()
    {
        fadeout = true;
    }

    public void FadeEnabled(bool isEnabled)
    {
        canFadeSound = isEnabled;

    }
}
