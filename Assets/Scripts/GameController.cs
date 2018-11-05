using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Game Object needed for the game
    public GameObject TIEFighterObject;
    public GameObject StarDestroyerObject1;
    public GameObject StarDestroyerObject2;
    public GameObject StarDestroyerObject3;
    public GameObject DeathStarObject;
    public GameObject R2D2PowerUp;
    private DeathStarHPController DeathStarHP;
   

    // Vector 3 position for each game object
    public Vector3 TIEFighterSpawnPosition;
    public Vector3 StarDestroyerSpawnPosition1;
    public Vector3 StarDestroyerSpawnPosition2;
    public Vector3 StarDestroyerSpawnPosition3;
    public Vector3 DeathStartSpawnPosition;
    public Vector3 R2D2SpawnPosition;

    // Text management for the game.
    public Text ScoreBoard;
    public Text GameOverText;
    public Text RestartText;
    private int score;
    private int tie_destroyed_counter;
    private int star_destroyer_counter;
    private bool callStarDestroyer = false;
    private bool callDeathStar = true;
    private bool callTIEFighter = true;
    private bool gameOver;
    private bool restart;

    // Start is called before the first frame update
    void Start()
    {
        restart = false;
        gameOver = false;
        GameOverText.text = "";
        RestartText.text = "";
        GameObject deathStarHPObject = GameObject.FindWithTag("DeathStarHP");
        if(deathStarHPObject != null) {
            DeathStarHP = deathStarHPObject.GetComponent<DeathStarHPController>();
        }
        Invoke("SpawnTIEFighter", 2);
        score = 0;
        tie_destroyed_counter = 0;
        star_destroyer_counter = 1;
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        if(restart) {
            if(Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(0);
            }
        }
        if(tie_destroyed_counter >= 7 && callTIEFighter) {
            Invoke("SpawnPowerUp", 1);
            Invoke("SpawnTIEFighter", 4);
            callTIEFighter = false;
        }
        if(tie_destroyed_counter >= 14) {
            // Invoke("SpawnPowerUp", 0);
            callStarDestroyer = true;
        }
        if(callStarDestroyer && star_destroyer_counter == 1) {
            Invoke("SpawnPowerUp", 1);
            Invoke("SpawnStarDestroyer1", 3);
            star_destroyer_counter++;
        } else if(callStarDestroyer && star_destroyer_counter == 2) {
            Invoke("SpawnStarDestroyer2", 9);
            star_destroyer_counter++;
        } else if(callStarDestroyer && star_destroyer_counter == 3) {
            Invoke("SpawnStarDestroyer3", 17);
            star_destroyer_counter++;
            callStarDestroyer = false;
        }
        if(star_destroyer_counter >= 3 && callDeathStar) {
            callDeathStar = false;
            Invoke("SpawnDeathStar", 30);   
        }
        if(gameOver) {
            RestartText.text = "press 'r' for restart";
            restart = true;
        }
    }
    void SpawnPowerUp() {
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(R2D2PowerUp, R2D2SpawnPosition, spawnRotation);
    }
    void SpawnTIEFighter() {
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(TIEFighterObject, TIEFighterSpawnPosition, spawnRotation);
    }

    void SpawnStarDestroyer1() {
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(StarDestroyerObject1, StarDestroyerSpawnPosition1, spawnRotation); 
    }
    void SpawnStarDestroyer2() {
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(StarDestroyerObject2, StarDestroyerSpawnPosition2, spawnRotation); 
    }

    void SpawnStarDestroyer3() {
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(StarDestroyerObject3, StarDestroyerSpawnPosition3, spawnRotation); 
    }

    void SpawnDeathStar() {
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(DeathStarObject, DeathStartSpawnPosition, spawnRotation);
        DeathStarHP.UpdateHealth();
    }
    public void TIEFighterDestroyed() {
        tie_destroyed_counter++;
    }

    public void AddScore(int newScoreValue) {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore() {
        ScoreBoard.text = "score: " + score;
    }

    public void GameOver() {
        GameOverText.text = "game over!";
        gameOver = true;
    }

}
