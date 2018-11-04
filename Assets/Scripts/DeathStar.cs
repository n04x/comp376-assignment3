﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStar : MonoBehaviour
{
    // When the death star will be damaged.
    public Sprite DamagedDeathStar;
    private DeathStarHPController DeathStarHP;
    private float DEATHSTAR_MOVEMENT = 10.0f;
    private float fireRate;
    private float nextFire;
    SpriteRenderer deathStarSpriteRenderer;
    int shieldLevel;
    bool shieldBroken = false;
    float shieldTimer = 0.0f;
    float shieldUpTimer = 5.0f;
    float timer;
    bool invincible = true;
    public GameObject EnemyBolt;
    public Transform ShotSpawn;
    void Start() {
        GameObject deathStarHPObject = GameObject.FindWithTag("DeathStarHP");
        if(deathStarHPObject != null) {
            DeathStarHP = deathStarHPObject.GetComponent<DeathStarHPController>();
        } 
        deathStarSpriteRenderer = GetComponent<SpriteRenderer>();  
        shieldLevel = 2;
        fireRate = 2.5f;
    }

    void Update() {
        timer += Time.deltaTime;
        if(timer < DEATHSTAR_MOVEMENT) {
            transform.Translate(-Vector2.up * Time.deltaTime);
        } else {
            invincible = false;
        }
        Shield();
        if(!invincible && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }
    void Shield() {
            if(shieldLevel == 2) {
                deathStarSpriteRenderer.color = Color.blue;
            } else if(shieldLevel == 1) {
                deathStarSpriteRenderer.color = Color.red;
            } else {
                deathStarSpriteRenderer.color = Color.white;
                shieldBroken = true;
            } 
        
        if(shieldBroken) {
            shieldTimer += Time.deltaTime;
        }
        if(shieldBroken && shieldTimer >= shieldUpTimer) {
            shieldLevel = 2;
            shieldBroken = false;
            shieldTimer = 0.0f;
        }
    }
    void OnTriggerEnter(Collider other) {
        // Debug.Log(other);
        if(other.tag == "Boundary" || other.tag == "EnemyBolt") {
            return;
        }
        if(invincible) {
            return;
        } else if(shieldBroken) {
            DeathStarHP.DamageTaken(1);
        } else {
            shieldLevel--;
            // this.GetComponent<SpriteRenderer>().sprite = DamagedDeathStar;
        }
    }
    void Shoot() {
        Instantiate(EnemyBolt, ShotSpawn.position, ShotSpawn.rotation);
    }   
}
