using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerContr : MonoBehaviour
{
    #region Variables
    public float horizontalInput;
    public float speed = 10.0f;
    float boundary = 20.5f;
    public GameObject flyingFood;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -boundary || transform.position.x > boundary)
        {
            transform.position = new Vector3(-boundary, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(flyingFood, transform.position, flyingFood.transform.rotation);
        }
    }
}
