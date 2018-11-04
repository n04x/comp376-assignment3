using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R2D2PowerUp : MonoBehaviour
{
    public float speed;
    private Arwing arwing;
    // Start is called before the first frame update
    void Start()
    {
        GameObject arwing_object = GameObject.FindWithTag("Arwing");
        arwing = arwing_object.GetComponent<Arwing>();
    }
    private void Update() {
        transform.Translate(-Vector3.forward * speed);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Boundary") {
            return;
        }
        if(other.tag == "Player") {
            arwing.Upgrade();
        }
        Destroy(gameObject);
    }
}
