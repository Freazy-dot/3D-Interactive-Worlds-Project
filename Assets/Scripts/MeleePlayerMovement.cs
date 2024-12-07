using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
public class MeleePlayerMovement : PlayerMovement
{
    private Vector3 velocity;
    private float mouseSensitivity = 100f;
    private readonly float gravity = -9.81f;
    private CharacterController controller;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float jumpInput = Input.GetAxis("Jump");
        Move(controller, moveInput);
        Jump(controller, jumpInput);
        RotateWithMouse();
    }

    protected override void Move(CharacterController controller, float moveInput)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = (controller.transform.right * moveHorizontal + controller.transform.forward * moveVertical) * speed;
        controller.Move(move * Time.deltaTime);
    }
private void RotateWithMouse()
{
    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

    Vector3 rotation = controller.transform.localEulerAngles;
    rotation.y += mouseX;
    controller.transform.localEulerAngles = rotation;

    // Optionally, you can also rotate the camera up and down
    // by modifying the camera's local rotation
    // cameraTransform.localEulerAngles = new Vector3(-mouseY, rotation.y, 0);
}
    protected override void Jump(CharacterController controller, float jumpInput)
    {
        
        if (controller.isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f; 

            
            if (jumpInput > 0)
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            }
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Apply vertical velocity
        controller.Move(velocity * Time.deltaTime);
    }

}
