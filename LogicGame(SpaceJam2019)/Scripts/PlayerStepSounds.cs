using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStepSounds : MonoBehaviour
{
    AudioSource audio;
    public AudioClip step1;
    public AudioClip step2;

    AudioClip[] AudioList = new AudioClip[2]; 

    public float stepDelay = 0.5f;
    float TimeCounter = 0f;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        AudioList.SetValue(step1, 0);
        AudioList.SetValue(step2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal")*Input.GetAxis("Vertical") != 0)
        {
            TimeCounter += Time.deltaTime;
        }


        if(TimeCounter >= stepDelay)
        {
            PlayStep();
            TimeCounter = 0;
        }

    }

    void PlayStep()
    {
        int soundIndex = Random.Range(0, 1);

        audio.PlayOneShot(step1);

    }
}
