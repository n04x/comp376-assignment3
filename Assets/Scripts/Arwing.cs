using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arwing : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    private CameraShake camShake;
    private float HORIZONTAL_LIMIT = 25.0f;
    private float VERTICAL_LIMIT = 6.0f;
    public float fire_rate;
    private float next_fire;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        GameObject camShakeObject = GameObject.FindWithTag("MainCamera");
        if(camShakeObject != null) {
            camShake = camShakeObject.GetComponent<CameraShake>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, vertical, 0.0f);
        transform.position += movement;
        // Check if boundary is respected:
        Vector3 boundary = transform.position;        
        boundary.x = Mathf.Clamp(boundary.x, -HORIZONTAL_LIMIT, HORIZONTAL_LIMIT);
        boundary.y = Mathf.Clamp(boundary.y, -VERTICAL_LIMIT, VERTICAL_LIMIT + 4);
        transform.position = boundary;

        if(Input.GetKeyDown("space") && Time.time > next_fire) {
            next_fire = Time.time + fire_rate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Bolt" || other.tag == "Boundary") {
            return;
        } else {
            camShake.FoxIsHit();
        }
    }
}
