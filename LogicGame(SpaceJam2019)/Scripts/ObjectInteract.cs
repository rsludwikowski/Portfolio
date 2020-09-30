using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    public Camera camera;

    public LayerMask interactMask;
    public GameObject holdingObj = null;

    bool isHolding = false;

    public float distanceToObj = 10f;
    public float holdingOffset = 2f;

    public float lerpingTime = 1f;
    float LPT;
    public float lerpingTimeStrenght = 20f;

    Rigidbody ObjRB;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!isHolding)
            {
                Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.tag == "Box")
                    {
                        holdingObj = hit.transform.gameObject;
                        isHolding = true;
                        LPT = lerpingTime;
                        if(holdingObj.GetComponent<Rigidbody>() != null)
                        {
                            ObjRB = holdingObj.GetComponent<Rigidbody>();
                            ObjRB.useGravity = false;
                        }
                    }

                    Debug.Log("HIT " + hit.transform.name);
                }
                else
                {
                    Debug.Log("NOT HIT");
                }
            }
            else
            {
                isHolding = false;
                holdingObj = null;
                if (ObjRB != null) ObjRB.useGravity = true;
            }

        }

       

       

        if (isHolding)
        {
            if (LPT>0)
            {
                holdingObj.transform.position = Vector3.Lerp(holdingObj.transform.position, camera.transform.position + camera.transform.forward * holdingOffset,lerpingTimeStrenght*Time.deltaTime);
                holdingObj.transform.eulerAngles = Vector3.Lerp(holdingObj.transform.eulerAngles, camera.transform.eulerAngles, lerpingTimeStrenght*Time.deltaTime*2); ;
            }
            else
            {
                holdingObj.transform.position = camera.transform.position + camera.transform.forward * holdingOffset;
                holdingObj.transform.eulerAngles = camera.transform.eulerAngles;
            }
        }


        LPT -= Time.deltaTime;

    }
   
}
