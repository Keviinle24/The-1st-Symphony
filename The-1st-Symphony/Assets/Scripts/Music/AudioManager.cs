using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    FadeInOut Fade;

    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    public string BgName;


private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(Instance.gameObject);  
            Instance = this;              
            DontDestroyOnLoad(gameObject); 
    }
    }

    void Start()
    {
        Fade = FindObjectOfType<FadeInOut>();

        Fade.FadeOut();
        if (BgName == "Level 5 BG")
        {
            Fade.FadeEnabled(false);
        }
        PlayMusic(BgName);
        

    }

        private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Ending")
        {
            Fade.FadeEnabled(true);
        }
        if (SceneManager.GetActiveScene().name == "StartGame")
        {
            DestroyCToS();
        }
    }

    public void DestroyCToS()
    {
        Destroy(gameObject);
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    
    {
         Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

}
