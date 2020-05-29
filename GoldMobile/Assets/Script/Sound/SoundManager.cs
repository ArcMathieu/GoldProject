using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public Sound[] musique;
    public Sound[] sfx;

    void Start()
    {
        Play("Main_Theme");
        Play("Cin_Theme");
    }

    void Awake()
    {
        instance = this;

        foreach(Sound x in musique)
        {
            x.source = gameObject.AddComponent<AudioSource>();
            x.source.clip = x.clip;
            x.source.volume = x.volume;
            x.source.loop = x.loop;
        }

        foreach (Sound y in sfx)
        {
            y.source = gameObject.AddComponent<AudioSource>();
            y.source.clip = y.clip;
            y.source.volume = y.volume;
            y.source.loop = y.loop;
        }
    }

    private void Update()
    {
        foreach (Sound x in musique)
        {
            x.source.volume = x.volume;
        }

        if (isCinematicPlaying)
        {
            StartCinMusic();
        }
        else
        {
            StopCinMusic();
        }
    }

    public bool isCinematicPlaying;

    public void killme()
    {
        isCinematicPlaying = false;
    }

    public void killmefirst()
    {
        isCinematicPlaying = true;
    }
    public void Play(string name)
    {
        Sound x = Array.Find(musique, sound => sound.name == name);
        Sound y = Array.Find(sfx, sound => sound.name == name);
        if (x != null)
        {
            x.source.Play();
        }
        else if(y != null)
        {
            y.source.Play();
        }
    }

    public void PlaySfx(string name)
    {
        Sound y = Array.Find(sfx, sound => sound.name == name);
        if (y != null)
        {
            y.source.Play();
        }
    }

    void StartCinMusic()
    {
        if (musique[0].volume >= 0f)
        {
            musique[0].volume -= 0.01f;
        }  
        if (musique[1].volume <= 0.8f)
        {  
           musique[1].volume += 0.01f;
        }

        if (musique[1].volume > 0.8f)
        {
            musique[1].volume = 0.8f;
        }
        if (musique[0].volume < 0f)
        {
            musique[0].volume = 0f;
        }
    }
    void StopCinMusic()
    {
        if (musique[0].volume <= 0.8f)
        {
            musique[0].volume += 0.01f;
        }
        if (musique[1].volume >= 0f)
        {
            musique[1].volume -= 0.01f;
        }

        if(musique[0].volume > 0.8f)
        {
            musique[0].volume = 0.8f;
        }
        if (musique[1].volume < 0f)
        {
            musique[1].volume = 0f;
        }
    }

    //FindObjectOfType<SoundManager>().Play("");
}
