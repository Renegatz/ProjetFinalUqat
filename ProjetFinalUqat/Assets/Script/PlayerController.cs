using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController controller;
    public float walkSpeed = 5f;
    public float sprintSpeed = 7f;
    private float currentSpeed;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public float crouchSmoothTime = 0.1f;
    float currentVelocity;
    private float CharacterHeight;
    private float CharacterStandHeight;
    public float CharacterCrouchHeight = 1f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3  velocity;
    bool isGrounded;
    public Camera cameraRef;
    private bool isCrouching;

    void Start()
    {
        CharacterHeight = controller.height;
        CharacterStandHeight = controller.height;
        currentSpeed = walkSpeed;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Gravity
        controller.Move(velocity * Time.deltaTime);
        if(isGrounded && velocity.y < 0){
            velocity.y = -1f;
            Debug.Log("grounded");
        }
        //Gravity


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        velocity.y +=gravity * Time.deltaTime;
        controller.Move(Vector3.ClampMagnitude(move,1.0f) * currentSpeed * Time.deltaTime);
        //Debug.Log(move);


        if(Input.GetButtonDown("Jump") && isGrounded){

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
          if(isCrouching){
              isCrouching = false;
          }else{
              isCrouching = true;
          }
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
          currentSpeed = sprintSpeed;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
          currentSpeed = walkSpeed;
        }

        if(isCrouching){
            //controller.height = CharacterCrouchHeight;
            controller.height = Mathf.SmoothDamp(controller.height,CharacterCrouchHeight,ref currentVelocity,crouchSmoothTime);
        }else{

            controller.height = Mathf.SmoothDamp(controller.height,CharacterStandHeight,ref currentVelocity,crouchSmoothTime);
        }
        Debug.Log(controller.height);
        Debug.Log(isCrouching);
    }
}
