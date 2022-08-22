using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDriver : MonoBehaviour
{
    public GameObject driver;
    Vector3 offset = new Vector3(0, 5, -10);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Offset camera behind the bus by adding the
        transform.position = driver.transform.position + offset;
    }
}
