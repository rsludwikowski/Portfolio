using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform bodyTransform;

    float sensitivity = 100f;

    float mouseX;
    float mouseY;

    float RotationY = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;

        RotationY -= mouseY;

        RotationY = Mathf.Clamp(RotationY, -90f, 90f);

        bodyTransform.Rotate(bodyTransform.up * mouseX);
        cameraTransform.localRotation = Quaternion.Euler(RotationY, 0, 0);

    }
}
