using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
public class MeleePlayerMovement : PlayerMovement
{
    private Vector3 velocity;
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
    }

    protected override void Move(CharacterController controller, float moveInput)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = (controller.transform.right * moveHorizontal + controller.transform.forward * moveVertical) * speed;
        controller.Move(move * Time.deltaTime);
    }

    protected override void Jump(CharacterController controller, float jumpInput)
    {
        // Check if the player is grounded
        if (controller.isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f; // Reset vertical velocity when grounded

            Debug.Log("Grounded");

            // Apply jump force if jump button is pressed
            if (jumpInput > 0)
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
                Debug.Log("Jumping");
            }
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Apply vertical velocity
        controller.Move(velocity * Time.deltaTime);
    }

}
