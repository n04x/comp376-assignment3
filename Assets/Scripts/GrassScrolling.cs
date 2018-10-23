﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassScrolling : MonoBehaviour
{
    public Renderer rend;
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * speed;
        rend.material.mainTextureOffset = new Vector2(0, -offset);
    }
}
