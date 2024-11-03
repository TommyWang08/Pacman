using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public GameManager gameManager;
    public Image life1;
    public Image life2;
    public Image life3;

    void Start(){
        if (gameManager == null){

            gameManager = FindObjectOfType<GameManager>();
        }

        UpdateLivesDisplay();
    }

    void Update(){
        UpdateLivesDisplay();
    }

    private void UpdateLivesDisplay(){
        
        int lives = gameManager.life; 

        life1.enabled = lives >= 1;
        life2.enabled = lives >= 2;
        life3.enabled = lives >= 3;
    }
}
