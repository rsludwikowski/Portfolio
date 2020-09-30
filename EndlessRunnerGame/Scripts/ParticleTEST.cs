using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTEST : MonoBehaviour
{
    public GameObject particleObst;
    Vector3 spawnPoint = new Vector3(0f,0f,0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(particleObst, spawnPoint, new Quaternion(0f, 0f, 0f, 0f));
            spawnPoint += transform.forward * 5;
        }
        
    }
}
