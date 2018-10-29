using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Information for TIE Fighter
    public GameObject TIEFighterObject;
    public Vector3 TIEFighterSpawnPosition;

    // Information for Star Destroyer.
    public GameObject StarDestroyerObject;
    public Vector3 StarDestroyerSpawnPosition;

    // Time to wait before spawning
    float startWait = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTIEFighter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTIEFighter() {
        yield return new WaitForSeconds(startWait);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(TIEFighterObject, TIEFighterSpawnPosition, spawnRotation);
    }
}
