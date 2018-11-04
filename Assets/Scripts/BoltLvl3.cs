using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltLvl3 : MonoBehaviour
{
    public float speed;
    public float direction;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Vector2.right * speed * Time.deltaTime);
    }
}
