using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    public Material materialRed;
    public GameObject Dorki;
    public Material materialGreen;

    public AudioClip clipPressed;
    public AudioClip clipReleased;

    AudioSource audio;

    bool soundPressed = false;

    public Collider col;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider colider)
    {
       
        if(!soundPressed)
        {
            audio.PlayOneShot(clipPressed);
            soundPressed = true;
        }
        

        Dorki.GetComponent<Animator>().SetBool("DorState", true);
        gameObject.GetComponent<MeshRenderer>().material = materialGreen;
        
    }

    void OnTriggerExit(Collider col)
    {

        if(soundPressed)
        {
            audio.PlayOneShot(clipReleased);
            soundPressed = false;
        }
        Dorki.GetComponent<Animator>().SetBool("DorState", false);
        gameObject.GetComponent<MeshRenderer>().material = materialRed;
    }




        // Update is called once per frame
    void Update()
    {
        
    }
}
