using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{    
    public GameObject explosion;
    GameObject explosion_temp;
    private GameController gameController;
    public GameObject SmokeHit;
    GameObject SmokeHit_temp;
    public int scoreValue;

    private void Start() {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Floor") {
            explosion_temp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
        if(other.tag == "Boundary" || other.tag == "EnemyBolt") {
            return;
        }
        if(other.tag == "Bolt" && gameObject.tag == "TIEFighters") {
            gameController.TIEFighterDestroyed();
        }
        Destroy(other.gameObject);
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        SmokeHit_temp = Instantiate(SmokeHit, transform.position, Quaternion.identity);
        gameController.AddScore(scoreValue);
    }
}
