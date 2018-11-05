using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIEShooting : MonoBehaviour
{
    public float time_between_attack;
    public GameObject shot;
    public Transform shotSpawn;
    AudioSource LaserSound;
    // Start is called before the first frame update
    void Start()
    {
        LaserSound = GetComponent<AudioSource>();
        StartCoroutine(SpawnShot());
    }

    IEnumerator SpawnShot() {
        while(true) {
            yield return new WaitForSeconds(time_between_attack);
            Instantiate(shot, transform.position, Quaternion.identity);
            LaserSound.Play();
        }
    }
}
