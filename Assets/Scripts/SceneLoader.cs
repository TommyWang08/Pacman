using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void LoadPacmanScene()
    {
        SceneManager.LoadScene("Pacman");
    }

    public void ExitToStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

}

