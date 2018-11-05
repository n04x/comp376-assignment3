using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arwing : MonoBehaviour
{
    public GameObject shot;
    public GameObject shotlvl2;
    public GameObject shotlvl3;
    public Transform shotSpawn;
    public Text FoxHPText;
    private CameraShake camShake;
    public GameObject explosion;
    GameObject explosion_temp;
    public GameObject SmokeHit;
    GameObject SmokeHit_temp;
    private float HORIZONTAL_LIMIT = 14.0f;
    private float VERTICAL_LIMIT = 7.5f;
    public float fire_rate;
    private float next_fire;
    private int lives;
    private bool dying = false;
    private bool smoke = false;
    Rigidbody rb;
    AudioSource LaserSound;

    // Start is called before the first frame update
    void Start()
    {
        LaserSound = GetComponent<AudioSource>();
        FoxHPText.text = "fox hp: " + lives;
        lives = 1;
        GameObject camShakeObject = GameObject.FindWithTag("MainCamera");
        if(camShakeObject != null) {
            camShake = camShakeObject.GetComponent<CameraShake>();
        }
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        FoxHPText.text = "fox hp: " + lives;
        if(lives <= 0) {
            dying = true;
        }
        if(!dying) {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontal, vertical, 0.0f);
            transform.position += movement;
            // Check if boundary is respected:
            Vector3 boundary = transform.position;        
            boundary.x = Mathf.Clamp(boundary.x, -HORIZONTAL_LIMIT, HORIZONTAL_LIMIT);
            boundary.y = Mathf.Clamp(boundary.y, -VERTICAL_LIMIT, VERTICAL_LIMIT + 2);
            transform.position = boundary;
            if(transform.position.y <= -7) {
                camShake.FoxIsHit();
            }
            if(Input.GetKeyDown("space") && Time.time > next_fire) {
                next_fire = Time.time + fire_rate;
                if(lives == 1) {
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                    LaserSound.Play();
                } else if(lives == 2) {
                    Instantiate(shotlvl2, shotSpawn.position, shotSpawn.rotation);
                    LaserSound.Play();
                } else if(lives >= 3) {
                    Instantiate(shotlvl3, shotSpawn.position, shotSpawn.rotation);
                    LaserSound.Play();
                }
            }
        } else if(dying) {
            Crashing();
        } 
    }
    private void Crashing() {
        rb.useGravity = true;
        if(!smoke) {
            SmokeHit_temp = Instantiate(SmokeHit, transform.position, Quaternion.identity);
        }
        smoke = true;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Bolt" || other.tag == "Boundary" || other.tag == "Upgrade") {
            return;
        } else if(dying) {
            explosion_temp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        } 
        else {
            DamageTaken();
            camShake.FoxIsHit();
        }
    }
    public void Upgrade() {
        lives++;
    }

    public void DamageTaken() {
        lives--;
    }
    
    public int GetHP() {
        return lives;
    }
}
