using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerCheckDarc : MonoBehaviour
{

    public Material materialRed;
    public GameObject Dorki;
    public Material materialGreen;

    void OnTriggerEnter(Collider colider) {
        if(colider.gameObject.name != "CubeBlack") {
            Dorki.GetComponent<Animator>().SetBool("DorState",true);
            gameObject.GetComponent<MeshRenderer>().material = materialGreen;
        }
       

    }

    void OnTriggerExit(Collider colider) {
        if(colider.gameObject.name != "CubeBlack") {
            Dorki.GetComponent<Animator>().SetBool("DorState",false);
            gameObject.GetComponent<MeshRenderer>().material = materialRed;
        }
       
    }
}
