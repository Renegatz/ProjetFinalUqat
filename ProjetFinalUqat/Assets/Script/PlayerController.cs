using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerBody;
    public float mouseSensivity = 200f;
    float xRotation = 0f;
    float yRotation = 0f;
    public float CharacterSpeed = 12f;
    public CharacterController controller;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * CharacterSpeed * Time.deltaTime);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f,90f);
        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation , 0f );


        //playerBody.Rotate(Vector3.up * mouseX);


    }
}
