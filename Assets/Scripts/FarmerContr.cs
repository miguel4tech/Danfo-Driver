using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerContr : MonoBehaviour
{

    public float horizontalInput;
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -20.5f || transform.position.x > 20.5f)
        {
            transform.position = new Vector3(-20, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }
}
