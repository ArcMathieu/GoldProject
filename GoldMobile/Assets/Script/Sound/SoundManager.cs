using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public bool isCinematicPlaying;
    public bool isFightBoss = false;
    public bool MusicChanged = false;
    public Sound[] musique;
    public Sound[] sfx;
    public AudioSource AudioSourceSFX;

    void Start()
    {

    }

    void Awake()
    {
        instance = this;

        foreach (Sound x in musique)
        {
            x.source = gameObject.AddComponent<AudioSource>();
            x.source.clip = x.clip;
            x.source.volume = x.volume;
            x.source.loop = x.loop;
        }

        //foreach (Sound y in sfx)
        //{
        //    y.source.clip = y.clip;
        //    y.source.volume = y.volume;
        //    y.source.loop = y.loop;
        //}
    }

    private void Update()
    {
        foreach (Sound x in musique)
        {
            if (x.source.isPlaying)
            {
                Debug.Log("Music Playing : " + x.source.clip.name);
            }
            x.source.volume = x.volume;

        }

        if (isCinematicPlaying)
        {
            Play("Cin_Theme");
        }
        else if (isFightBoss)
        {
            Play("Boss_Theme");   
        }
        else
        {
            Play("Main_Theme");
        }
    }



    public void AmbiantMusic()
    {
        MusicChanged = false;
        isCinematicPlaying = false;
    }

    public void CinMusic()
    {
        MusicChanged = false;
        isCinematicPlaying = true;
    }

    public void SoundBoss()
    {
        MusicChanged = false;
        isFightBoss = true;
    }

    public void stopCurrentMusic()
    {
        if (musique[0].volume != 0f || musique[1].volume != 0f)
        {
            musique[0].volume = 0f;
            musique[1].volume = 0f;
        }
    }

    public void Play(string name)
    {
        //      Sound x = Array.Find(musique, sound => sound.name == name);
        ////      Sound y = Array.Find(sfx, sound => sound.name == name);
        //      if (x != null)
        //      {
        //          x.source.Play();
        //      }
        if (!MusicChanged)
        {
            foreach (Sound x in musique)
            {
                if (x.name == name)
                {
                    
                    x.source.Play();
                }
                else
                {
                    x.source.Stop();
                }
            }
            MusicChanged = true;
        }
        //else if (y != null)
        //{
        //    y.source.Play();
        //}
    }

    public void PlaySfx(string name)
    {
        Sound y = Array.Find(sfx, sound => sound.name == name);
        AudioSourceSFX.PlayOneShot(y.clip);

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

        if (musique[0].volume > 0.8f)
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
