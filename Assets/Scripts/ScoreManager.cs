using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour{
    public TextMeshProUGUI scoreText;
    private GameManager gameManager;

    void Start(){

        gameManager = FindObjectOfType<GameManager>();

    }

    void Update(){

        if (gameManager != null){
            
            scoreText.text = "Score: " + gameManager.score.ToString();
        }
    }
}
