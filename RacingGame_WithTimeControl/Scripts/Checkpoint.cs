using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool isMeta = false;
    private List<Player> playersPastThisPoint = new List<Player>();
    private void OnTriggerEnter(Collider other)
    {
        if(!isMeta && other.gameObject.GetComponent<Player>() != null  && !playersPastThisPoint.Contains(other.gameObject.GetComponent<Player>()))
        {
            other.gameObject.GetComponent<Player>().OnPassedCheckpoint(this);
            playersPastThisPoint.Add(other.gameObject.GetComponent<Player>());
        }
         else if(other.gameObject.GetComponent<Player>() != null && isMeta && other.gameObject.GetComponent<Player>().isPlayerCapableToFinish(this))
        {
            other.gameObject.GetComponent<Player>().resetCheckpoints();
        }
    }

    public void resetCheckpointStatus(Player player)
    {
        playersPastThisPoint.Remove(player);
    }

    public float getNumberOfCheckpoints()
    {
        return transform.parent.GetComponentsInChildren<Checkpoint>().Length;
    }
} 
