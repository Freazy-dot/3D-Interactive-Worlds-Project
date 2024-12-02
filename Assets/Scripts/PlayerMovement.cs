using UnityEngine;

public abstract class PlayerMovement : MonoBehaviour
{
    [SerializeField]protected float speed;
    [SerializeField]protected float jumpForce;

    protected abstract void Move(CharacterController controller, float moveInput);
    protected abstract void Jump(CharacterController controller, float jumpInput);

}
