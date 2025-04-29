using UnityEngine;

public class Wizard : MonoBehaviour
{
    // Speed at which the wizard moves
    public float moveSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        // Initialize movement as a zero vector
        Vector3 movement = Vector3.zero;

        // Check for movement input on each axis
        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector3.up;  // Move up
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.down;  // Move down
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;  // Move right
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;  // Move left
        }

        // Apply the movement to the transform position with time-based scaling
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
