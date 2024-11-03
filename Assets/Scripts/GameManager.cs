using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    public Ghost[] ghosts;
    public PacStu pacstu;
    public Transform pellets;
    private TimerManager timerManager;
    public int score{
        get;
        private set;
    } =0;
    public int life{
        get;
        private set;
    }

    private void Start(){
        NewGame();
    }

    private void NewGame(){
        SetScore(0);
        Setlife(3);

        timerManager = FindObjectOfType<TimerManager>();
        if (timerManager != null){
            timerManager.ResetTimer();
            timerManager.StartTimer();
        }
    }

    private void NewRound(){

        foreach(Transform pellet in this.pellets){
            pellet.gameObject.SetActive(true);
        }

        ReState();
    }

    private void ReState(){

        this.pacstu.gameObject.SetActive(true);

        for(int i=0; i < this.ghosts.Length; i++){
            this.ghosts[i].gameObject.SetActive(true);
        }
    }

    private void GameOver(){

        this.pacstu.gameObject.SetActive(false);

        for(int i=0; i < this.ghosts.Length; i++){
            this.ghosts[i].gameObject.SetActive(false);
        }
    }

    private void SetScore(int score){
        this.score = score;
    }

    private void Setlife(int life){
        this.life = life;
    }

    public void GhostDead(Ghost ghost){
        SetScore(this.score + ghost.points);
    }

    public void PacStuDead(){
        
        this.pacstu.gameObject.SetActive(false);

        Setlife(this.life - 1);

        if(this.life < 0){
            GameOver();
        }else{
            Invoke("ReState",3.0f);
        }
    }

    private void Update(){
        if(this.life < 0){

            EndGame();

            if(Input.GetKeyDown(KeyCode.Space)){
                NewGame();
            }
        }
    }

    public void PelletEaten(Pellet pellet){

        pellet.gameObject.SetActive(false);

        SetScore(this.score + pellet.points);

        if (!HasRemainingPellets()){
            pacstu.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3f);
        }
    }

    public void PowerEaten(Power pellet)
    {
        // for (int i = 0; i < ghosts.Length; i++) {
        //     ghosts[i].frightened.Enable(pellet.duration);
        // }

        PelletEaten(pellet);
    }

    private bool HasRemainingPellets(){

        foreach (Transform pellet in this.pellets){
            if (pellet.gameObject.activeSelf){
                return true;
            }
        }

        EndGame();

        return false;
    }

    public void EndGame()
    {
        if (timerManager != null)
        {
            timerManager.StopTimer();
        }
    }
}
