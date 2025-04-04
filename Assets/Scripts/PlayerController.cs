using UnityEngine;

public class PlayerController : MonoBehaviour
{
    MovementCharactor movementCharactor;
    KeyCode jumpKeyCode = KeyCode.Space;

    void Start()
    {
        movementCharactor = GetComponent<MovementCharactor>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        movementCharactor.MoveTo(new Vector3(x, 0, z).normalized);

        if (Input.GetKeyDown(jumpKeyCode))
        {
            movementCharactor.JumpTo();
        }
    }
}
