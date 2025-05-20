using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Wizard : MonoBehaviour
{
    public GameObject fireballPrefab;

    void Update()
    {
        Movement();
        Casting();
    }

    private void Movement()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement = movement + new Vector3(0, 1, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.down;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
        }

        // Option 1
        if (Input.GetKey(KeyCode.W) ^ Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A) ^ Input.GetKey(KeyCode.D))
            {
                movement *= 0.7f;
            }
        }

        // Option 2 easy Solution
        movement.Normalize();

        // Option 3 bei Pseudo Controller
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        transform.position += movement * Time.deltaTime * 3;
    }

    private void Casting()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Vector3 position = transform.position + new Vector3(-0.5f, 0.4f, 0);
            GameObject obj = Instantiate(fireballPrefab, position, Quaternion.identity);
        }
    }


}