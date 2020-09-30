using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TPLevel : MonoBehaviour
{
        // Start is called before the first frame update
    

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("COL KURWA");
        if (col.tag == "Player")
        {
            Debug.Log("NO PLAYER NO");
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
