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

    private float HORIZONTAL_LIMIT = 25.0f;
    private float VERTICAL_LIMIT = 7.5f;
    public float fire_rate;
    private float next_fire;
    private int lives;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        FoxHPText.text = "fox hp: " + lives;
        lives = 1;
        GameObject camShakeObject = GameObject.FindWithTag("MainCamera");
        if(camShakeObject != null) {
            camShake = camShakeObject.GetComponent<CameraShake>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        FoxHPText.text = "fox hp: " + lives;
        if(lives == 0) {
            Destroy(gameObject);
        }
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
            } else if(lives == 2) {
                Instantiate(shotlvl2, shotSpawn.position, shotSpawn.rotation);
            } else if(lives == 3) {
                Instantiate(shotlvl3, shotSpawn.position, shotSpawn.rotation);
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Bolt" || other.tag == "Boundary" || other.tag == "Upgrade") {
            return;
        } else {
            camShake.FoxIsHit();
        }
    }
    public void Upgrade() {
        lives++;
    }
}
