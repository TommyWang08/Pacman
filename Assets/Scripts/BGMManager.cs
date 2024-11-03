using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip introMusic;
    public AudioClip ghostNormalMusic;
    public AudioClip ghostScaredMusic;
    public AudioClip ghostDeadMusic;

    private static BackgroundMusicManager instance;

    void Awake(){

        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);

        }else{

            Destroy(gameObject); 
            return;
        }
    }

    void Start(){

        if (SceneManager.GetActiveScene().name == "StartScene"){

            PlayIntroMusic();

        }else if (SceneManager.GetActiveScene().name == "Pacman"){

            PlayGhostNormalMusic();
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode){

        if (scene.name == "Pacman"){

            PlayGhostNormalMusic();
        }
    }

    void PlayIntroMusic(){

        if (audioSource != null && introMusic != null){

            audioSource.clip = introMusic;
            audioSource.loop = false;
            audioSource.Play();
            Invoke("PlayGhostNormalMusic", introMusic.length);
        }
    }

    void PlayGhostNormalMusic(){

        if (audioSource != null && ghostNormalMusic != null){

            audioSource.clip = ghostNormalMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void PlayGhostScaredMusic(){

        if (audioSource != null && ghostScaredMusic != null){

            audioSource.clip = ghostScaredMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void PlayGhostDeadMusic(){

        if (audioSource != null && ghostDeadMusic != null){
            
            audioSource.clip = ghostDeadMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
