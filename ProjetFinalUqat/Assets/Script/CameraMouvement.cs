using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerBodyRef;
    public float mouseSensivity = 200f;
    float xRotation = 0f;
    float yRotation = 0f;
    public float CharacterSpeed = 12f;
    //public CharacterController controller;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f,90f);
        //yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, 0f , 0f );
        playerBodyRef.Rotate(Vector3.up * mouseX);

        
    }
}
