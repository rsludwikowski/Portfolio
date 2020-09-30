using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNext : MonoBehaviour
{

   
    [SerializeField]
    SpawnFloor ManagerScript;

    GameObject FloorManager;

    GameObject player;
    GameObject[] ObjOnScene;
    GameObject despawnPoint;
    bool notSpawned = true;


    float MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("FloorPlayer");
        FloorManager = transform.parent.gameObject;
        
        ManagerScript = (SpawnFloor) transform.parent.gameObject.GetComponent<SpawnFloor>();
        MoveSpeed = ManagerScript.FloorMoveSpeed;

        despawnPoint = player.transform.GetChild(0).gameObject;
        transform.Translate(0f, 0f, -MoveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, -MoveSpeed*Time.deltaTime);






        

        if (transform.position.z <= player.transform.position.z && notSpawned)
        {
           ManagerScript.SpawnNextFC();
            notSpawned = false;
        }

        if (transform.position.z <= despawnPoint.transform.position.z)
        {
            Destroy(gameObject);
        }

    }
}
