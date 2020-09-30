using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed;
    float distanceTravelled;
    public float chillwagonOffset;

    void Update()
    {
        float offset = chillwagonOffset + GetComponentInParent<ChillPociag>().GetTrainOffset();

        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + offset);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + offset);
    }
}
