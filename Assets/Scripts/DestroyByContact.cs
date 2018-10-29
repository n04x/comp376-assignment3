using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    private GameController gameController;

    private void Start() {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Boundary") {
            return;
        }        
        Destroy(other.gameObject);
        Destroy(gameObject);
        if(other.tag == "Bolt" && gameObject.tag == "TIEFighters") {
            gameController.TIEFighterDestroyed();
        }
    }
}
