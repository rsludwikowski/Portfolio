using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFloor : MonoBehaviour
{

    public int forwardFloorCount = 5;

    public float FloorMoveSpeed = 22f;

    public GameObject FloorOBJ;

    private GameObject attachPoint;
    private GameObject NewFloor;
    private GameObject spawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {

        NewFloor = transform.GetChild(0).gameObject;
        

        attachPoint = NewFloor.transform.GetChild(0).gameObject;
        spawnPoint = NewFloor.transform.GetChild(1).gameObject;
        
        Debug.Log("FloorPos: " + transform.GetChild(0).position +
            "    AttachPointPos: " + attachPoint.transform.position + 
            "    SpawnPointPos: " + spawnPoint.transform.position);


        for (int i = 0; i < forwardFloorCount;i++)
        {
            SpawnNextFC();
        }
               

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SpawnNextFC()
    {

        Vector3 spawnPos;
        Vector3 Dist = NewFloor.transform.position - spawnPoint.transform.position;
        Debug.Log("Dist: " + Dist);

        spawnPos = attachPoint.transform.position + Dist;

        NewFloor = Instantiate(FloorOBJ, spawnPos,FloorOBJ.transform.rotation);
        NewFloor.transform.SetParent(transform);
        attachPoint = NewFloor.transform.GetChild(0).gameObject;
        spawnPoint = NewFloor.transform.GetChild(1).gameObject;


    }
}
