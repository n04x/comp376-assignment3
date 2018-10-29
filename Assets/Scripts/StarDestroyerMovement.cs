using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDestroyerMovement : MonoBehaviour
{
    // Going to Right direction if true.
    // GOing to Left direction if false.
    public bool going_right;
    public bool shoot;
    public float speed;
    public GameObject EnemyBolt;
    public Transform ShotSpawn;

    void Start() {
        if(shoot) {
            Invoke("Shoot", 2.5f);
        }    
    }
    void Update()
    {
        if(going_right) {
            transform.Translate(Vector3.right * speed);
        } else {
            transform.Translate(-Vector3.right * speed);
        }    
    }

    void Shoot() {
        Instantiate(EnemyBolt, ShotSpawn.position, ShotSpawn.rotation);
    }
}
