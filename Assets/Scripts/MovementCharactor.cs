using UnityEngine;

public class MovementCharactor : MonoBehaviour
{
    public GameObject bananaMan;

    float moveSpeed = 5f;
    float jumpForce = 3f;
    float gravity = -9.81f;

    Vector3 moveDirection;
    CharacterController characterController;

    void Start()
    {
        characterController = bananaMan.GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!characterController.isGrounded)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
    }

    public void JumpTo()
    {
        if (characterController.isGrounded)
        {
            moveDirection.y = jumpForce;
        }
    }
}
