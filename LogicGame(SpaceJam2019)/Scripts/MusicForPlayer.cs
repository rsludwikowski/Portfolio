using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicForPlayer : MonoBehaviour
{
    public AudioSource soundBitch;

    bool quiet = true;

    public moveToAnotherSide JungenSide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(JungenSide.isDarkState)
        {
            if (quiet)
            {
                soundBitch.Play();
                soundBitch.loop = true;
                quiet = false;
            }
        }
        else
        {
            if (!quiet)
            {
                soundBitch.Stop();
                quiet = true;
            }
        }
    }
}
