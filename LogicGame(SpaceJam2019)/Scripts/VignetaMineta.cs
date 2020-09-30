using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetaMineta : MonoBehaviour
{

    public moveToAnotherSide JumpMamba;

    bool vignetaEnabled = false;

    Vignette vigneta;
    PostProcessVolume volume;
    // Start is called before the first frame update
    void Start()
    {
        volume = gameObject.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out vigneta);
        vigneta.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(JumpMamba.isDarkState)
        {
            if(!vignetaEnabled)
            {
                vigneta.active = true;
                vignetaEnabled = true;
            }
        }
        else
        {
            if(vignetaEnabled)
            {
                vigneta.active = false;
                vignetaEnabled = false;
            }
        }
    }
}
