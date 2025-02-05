using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    [SerializeField] private AudioSource BG_Music;

    public bool fadein = false;
    public bool fadeout = false;


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
}
