using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArwingHit : MonoBehaviour
{
    public GameObject arwingSmoke;
	GameObject arwingSmokeTemp;
	private GameController gameController;
	private Arwing arwing;
    void Start() {
        GameObject arwing_object = GameObject.FindWithTag("Arwing");
        arwing = arwing_object.GetComponent<Arwing>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }
    void OnTriggerEnter(Collider other) {
		if(other.tag == "Boundary") {
			return;
		}
		if(other.tag == "EnemyBolt") {
			return;
		}
		if(other.tag == "Player") {
			arwing.DamageTaken();
			if(arwing.GetHP() == 0) {
				gameController.GameOver();
			}
			Destroy(gameObject);
		}
	}
}
