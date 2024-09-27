using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour{
    
    public AudioSource audioSource;
    public AudioClip introMusic;
    public AudioClip ghostNormalMusic;
    public AudioClip ghostScaredMusic;
    public AudioClip ghostDeadMusic;


    void Start(){
        if (audioSource != null && introMusic != null && ghostNormalMusic != null){

            audioSource.clip = introMusic;
            audioSource.Play();
            
            audioSource.loop = false; 
            Invoke("PlayGhostNormalMusic", introMusic.length);
        }
    }

    void PlayGhostNormalMusic(){
        audioSource.clip = ghostNormalMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}
