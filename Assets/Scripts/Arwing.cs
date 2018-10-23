using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arwing : MonoBehaviour
{
    private float HORIZONTAL_LIMIT = 9.0f;
    private float VERTICAL_LIMIT = 2.0f;
    public float speed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
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
        boundary.y = Mathf.Clamp(boundary.y, -VERTICAL_LIMIT, VERTICAL_LIMIT);
        transform.position = boundary;
        // transform.position += new Vector3 (Mathf.Clamp(speed * Time.deltaTime, -2.8f, 2.8f), 0.0f, 0.0f);
    }
}
