using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstDestroy : MonoBehaviour
{
    GameObject Obst;
    GameObject ObstMesh;
    ParticleSystem particleEffect;


    public float killTime = 3f;

    float playTime = 0f;
    bool countDown = false;
    bool alive = true;

    public void KillTarget()
    {
        Destroy(ObstMesh);
        particleEffect.Play();
        countDown = true;
        alive = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        particleEffect = transform.GetChild(1).GetComponent<ParticleSystem>();
        Obst = GetComponent<GameObject>();
        ObstMesh = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.V) && alive)
        {
            KillTarget(); // TO REMOVE
        }
        
       if(countDown)
        {
            if(playTime >= killTime)
            {
                Destroy(gameObject);
            }
            playTime += Time.deltaTime;
        }
      
    }
    
}
