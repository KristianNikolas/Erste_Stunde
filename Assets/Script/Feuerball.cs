using UnityEngine;

public class Feuerball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(-12,0,0) * Time.deltaTime;
    }
}
