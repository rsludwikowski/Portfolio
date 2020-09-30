using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToAnotherSide : MonoBehaviour
{

    public bool isDarkState = false;//1-ciemny . 0-jasny
    public Transform player;
    public Transform ghost;
    bool isInWall=false;
    public LayerMask groundMask;

    public float distanceBetweenScean = 11f;


    // Update is called once per frame
    void LateUpdate() {
        

        if(Input.GetKeyDown(KeyCode.E)) {
            if(Physics.CheckSphere(ghost.position,0.5f,groundMask)) {
                //Physics.CheckSphere()
                //Physics.CheckCapsule()
                
                Debug.Log("Hit");
            }
            else {

                if(isDarkState) {
                    isDarkState = false;
                    player.localPosition = new Vector3(player.localPosition.x,player.localPosition.y,player.localPosition.z - distanceBetweenScean);

                }

                else {
                    isDarkState = true;
                    player.localPosition = new Vector3(player.localPosition.x,player.localPosition.y,player.localPosition.z + distanceBetweenScean);

                }
            }
        }
        if(isDarkState) {
            ghost.localPosition = new Vector3(player.localPosition.x,player.localPosition.y,player.localPosition.z - distanceBetweenScean);
        }
        else {
            ghost.localPosition = new Vector3(player.localPosition.x,player.localPosition.y,player.localPosition.z + distanceBetweenScean);
        }
    }
    /*
    static bool moveToAnotherSide(Transform t,float distanceBetweenScean,bool isDarkState) {
        if(isDarkState) {
            isDarkState = false;
            t.transform.localPosition = new Vector3(t.transform.localPosition.x,t.transform.localPosition.y,t.transform.localPosition.z - distanceBetweenScean); //SetParent localScale.Set(0,4,0);
        }

        else {
            isDarkState = true;
            t.transform.localPosition = new Vector3(t.transform.localPosition.x,t.transform.localPosition.y,t.transform.localPosition.z + distanceBetweenScean); //SetParent localScale.Set(0,4,0);
        }

        return true;
    }
    */
}

