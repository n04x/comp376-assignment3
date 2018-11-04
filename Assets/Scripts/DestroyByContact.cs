using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    private GameController gameController;
    public int scoreValue;

    private void Start() {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Boundary" || other.tag == "EnemyBolt") {
            return;
        }
        if(other.tag == "Bolt" && gameObject.tag == "TIEFighters") {
            gameController.TIEFighterDestroyed();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        gameController.AddScore(scoreValue);
    }
}
