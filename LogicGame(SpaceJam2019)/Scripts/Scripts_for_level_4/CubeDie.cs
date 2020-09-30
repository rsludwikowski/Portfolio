using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDie : MonoBehaviour
{
    public Transform cube;
    public Vector3 start;

    // Start is called before the first frame update
    void Start(){
        
                             
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "enemy") {
            cube.localPosition = start;
        }
    }

}
