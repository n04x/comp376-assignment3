using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDestroyerMovement : MonoBehaviour
{
    // Going to Right direction if true.
    // GOing to Left direction if false.
    public bool going_right;
    public Sprite StarDestroyerFire;
    public bool stopping;
    public bool shoot;
    private bool moving;
    private float fireRate;
    private float nextFire;
    public float speed;
    public GameObject EnemyBolt;
    public Transform ShotSpawn;
    public Transform ShotSpawn2;

    void Start() {
        moving = true;
        fireRate = 2.0f;
    }
    void Update()
    {
        if(stopping) {
            CheckPosition();
        }
        if(shoot && transform.position.x == 0) {
            Shoot();
        }
        if(moving) {
           MovingStarDestroyer();   
        } else if(stopping && !moving) {
            if(Time.time > nextFire) {
                nextFire = Time.time + fireRate;
                Shoot();
            }
        }
    }

    void CheckPosition() {
        if(transform.position.x >= -1) {
            moving = false;
        }
    }
    void MovingStarDestroyer() {
        if(going_right && moving) {
            transform.Translate(Vector3.right * speed);
        } else {
            transform.Translate(-Vector3.right * speed);
        }
    }
    void Stopped() {
        moving = false;
    }
    void Shoot() {
        // this.GetComponent<SpriteRenderer>().sprite = StarDestroyerFire;
        Instantiate(EnemyBolt, ShotSpawn.position, ShotSpawn.rotation);
        Instantiate(EnemyBolt, ShotSpawn2.position, ShotSpawn2.rotation);
    }
}
