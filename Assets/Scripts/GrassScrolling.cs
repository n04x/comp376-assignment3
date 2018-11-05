using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassScrolling : MonoBehaviour
{
    public Renderer rend;
    public float speed = 0.5f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject deathstar = GameObject.FindWithTag("DeathStar");
        if(deathstar == null) {
            float offset = Time.time * speed;
            rend.material.mainTextureOffset = new Vector2(0, -offset);
        } else {
            timer += Time.deltaTime;
            if(timer < 2.0f) {
                float offset = Time.time * (speed / 2.0f);
                rend.material.mainTextureOffset = new Vector2(0, -offset);
            }
        }
    }
}
