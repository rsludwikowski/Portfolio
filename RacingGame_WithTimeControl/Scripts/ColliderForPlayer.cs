using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderForPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.GetComponent<TimeChangeableObject>())
        {
            
            TimeChangeableObject target = other.gameObject.GetComponent<TimeChangeableObject>();
            if (isObjectHiddenByObstacle(target))
            {
               
                return;
            }

            GetComponentInParent<Player>().setTarget(target);
            
        }
    }
    bool isObjectHiddenByObstacle(TimeChangeableObject target)
    {
        //float distanceToPlayer = Vector3.Distance(GetComponentInParent<TimeChangeableObject>().transform.position, target.TimeChangeableObjectBody.position);
        float distanceToPlayer = Vector3.Distance(transform.position, target.TimeChangeableObjectBody.position);
       // RaycastHit[] hits = Physics.RaycastAll(GetComponentInParent<TimeChangeableObject>().transform.position, target.TimeChangeableObjectBody.position - GetComponentInParent<TimeChangeableObject>().transform.position, distanceToPlayer);
        RaycastHit[] hits = Physics.RaycastAll(transform.position, target.TimeChangeableObjectBody.position - transform.position, distanceToPlayer);
        foreach (RaycastHit hit in hits)
        {
            // ignore the enemy's own colliders (and other enemies)
            if (hit.transform.tag == "Player")
                continue;

            // if anything other than the player is hit then it must be between the player and the enemy's eyes (since the player can only see as far as the player)
            if (hit.transform.tag != "TimeChangeableObject")
            {
                return true;
            }
        }
        // if no objects were closer to the enemy than the player return false (player is not hidden by an object)
        return false;

    }
}
