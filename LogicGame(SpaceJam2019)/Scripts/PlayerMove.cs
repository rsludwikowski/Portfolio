using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    float MoveForvard;
    float MoveSideways;

    public Transform groundCheck;
    public float jumpHeight = 10f;

    bool isGrounded;
    public float groundDistance = 0.4f;

    public float velocity = 50f;

    public LayerMask layerMask;

    public Transform cameraTransform;

    public float sensitivity = 20f;

    float mouseX;
    float mouseY;

    float rotationY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance,layerMask);
        if (isGrounded)
        {
            MoveForvard = Input.GetAxis("Vertical");
            MoveSideways = Input.GetAxis("Horizontal");
        }

        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;

        rotationY -= mouseY;

        rotationY = Mathf.Clamp(rotationY, -90, 90);

        transform.Rotate(transform.up * mouseX);
        cameraTransform.localRotation = Quaternion.Euler(rotationY, 0, 0);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Jump");

            rb.AddForce(Vector3.up*Mathf.Sqrt(2f*Physics.gravity.magnitude*jumpHeight),ForceMode.VelocityChange);
        }

        

    }

    void FixedUpdate()
    {

        Vector3 move = transform.right * MoveSideways + transform.forward * MoveForvard;



        rb.MovePosition((transform.position + move * velocity * Time.fixedDeltaTime));
    }
}
