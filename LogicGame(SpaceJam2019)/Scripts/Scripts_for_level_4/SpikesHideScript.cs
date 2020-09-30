using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesHideScript : MonoBehaviour
{
    public Material materialRed;
    public GameObject Spikes;
    public Material materialGreen;

    void OnTriggerEnter(Collider colider) {
        Spikes.gameObject.SetActive(false);
        gameObject.GetComponent<MeshRenderer>().material = materialGreen;    
    }

    void OnTriggerExit(Collider col) {
        Spikes.gameObject.SetActive(true);
        gameObject.GetComponent<MeshRenderer>().material = materialRed;
    }

}
