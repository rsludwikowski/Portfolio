using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChillPociag : MonoBehaviour
{
    public float trainNumber;

    public float GetTrainOffset()
    {
        return trainNumber * (GetComponentsInChildren<Follower>().Length+1);
    }

}
