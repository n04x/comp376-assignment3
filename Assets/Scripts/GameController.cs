using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Information for TIE Fighter
    public GameObject TIEFighterObject;
    public Vector3 TIEFighterSpawnPosition;

    // Information for Star Destroyer.
    public GameObject StarDestroyerObject1;
    public GameObject StarDestroyerObject2;
    public GameObject StarDestroyerObject3;
    public GameObject DeathStarObject;
    public Vector3 StarDestroyerSpawnPosition1;
    public Vector3 StarDestroyerSpawnPosition2;
    public Vector3 StarDestroyerSpawnPosition3;
    public Vector3 DeathStartSpawnPosition;

    // Time to wait before spawning
    private int tie_destroyed_counter;
    private int star_destroyer_counter;
    private bool callStarDestroyer = false;
    private bool callDeathStar = true;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnTIEFighter", 2);
        tie_destroyed_counter = 0;
        star_destroyer_counter = 1;
        // StartCoroutine(SpawnTIEFighter());
    }

    // Update is called once per frame
    void Update()
    {
        if(tie_destroyed_counter > 6) {
            callStarDestroyer = true;
        }
        if(callStarDestroyer && star_destroyer_counter == 1) {
            Invoke("SpawnStarDestroyer1", 2);
            star_destroyer_counter++;
        } else if(callStarDestroyer && star_destroyer_counter == 2) {
            Invoke("SpawnStarDestroyer2", 8);
            star_destroyer_counter++;
        } else if(callStarDestroyer && star_destroyer_counter == 3) {
            Invoke("SpawnStarDestroyer3", 16);
            star_destroyer_counter++;
            callStarDestroyer = false;
        }
        if(star_destroyer_counter >= 3 && callDeathStar) {
            callDeathStar = false;
            Invoke("SpawnDeathStar", 25);
        }
    }
    void SpawnTIEFighter() {
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(TIEFighterObject, TIEFighterSpawnPosition, spawnRotation);
    }

    void SpawnStarDestroyer1() {
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(StarDestroyerObject1, StarDestroyerSpawnPosition1, spawnRotation); 
    }
    void SpawnStarDestroyer2() {
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(StarDestroyerObject2, StarDestroyerSpawnPosition2, spawnRotation); 
    }

    void SpawnStarDestroyer3() {
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(StarDestroyerObject3, StarDestroyerSpawnPosition3, spawnRotation); 
    }

    void SpawnDeathStar() {
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(DeathStarObject, DeathStartSpawnPosition, spawnRotation);
    }
    public void TIEFighterDestroyed() {
        tie_destroyed_counter++;
    }


}
