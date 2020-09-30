using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedMeter : MonoBehaviour
{
    [SerializeField]
    private RectTransform rotationPoint;
    private float maxRot = 150f;
    private float maxSpeed = 15.0f;
    [SerializeField]
    private Rigidbody watchedPlayerBody;

    void FixedUpdate()
    {
        float speed = watchedPlayerBody.velocity.magnitude;
        float maxSpeedPercentage = speed / maxSpeed * 100;
        if(-maxSpeedPercentage <= -maxRot)
        {
            rotationPoint.transform.eulerAngles = new Vector3(rotationPoint.transform.eulerAngles.x, rotationPoint.transform.eulerAngles.y, -maxRot);
        }
        else
        {
            rotationPoint.transform.eulerAngles = new Vector3(rotationPoint.transform.eulerAngles.x, rotationPoint.transform.eulerAngles.y, -maxSpeedPercentage);
        }
        Debug.Log(rotationPoint.transform.eulerAngles.z);
    }
}
