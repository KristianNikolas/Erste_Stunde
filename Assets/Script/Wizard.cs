using UnityEngine;

public class Wizard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float f = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + new Vector3(0, 3, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * Time.deltaTime * 3;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * 3;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * 3;
        }
    }


}
