using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    public AudioSource musicSource;  
    public AudioSource sfxSource;    
    public AudioClip hitSound;        
    public AudioClip missSound;       
    public AudioClip backgroundMusic; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        PlayBackgroundMusic(); 
    }


    public void PlayBackgroundMusic()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true; 
        musicSource.Play();
    }

 
    public void PlayHitSound()
    {
        sfxSource.PlayOneShot(hitSound);
    }

    public void PlayMissSound()
    {
        sfxSource.PlayOneShot(missSound);
    }
}
