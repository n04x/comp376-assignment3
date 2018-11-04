using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIEFighterMovement : MonoBehaviour
{
    
    float TIE_FIGHTER_STATIC_POSITION = 0.0f;
    public float speed;
    float movement;
    // Update is called once per frame
    void Update()
    {
        // movement += Time.deltaTime;
        if(gameObject.transform.position.z > TIE_FIGHTER_STATIC_POSITION) {
            transform.Translate(-Vector3.forward * speed);
        }
    }
}
