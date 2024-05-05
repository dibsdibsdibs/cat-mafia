using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float horizontalInput;
    [SerializeField] public float verticalInput;
    [SerializeField] public float speed = 5.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;
        
        if (horizontalInput != 0 && verticalInput != 0) 
        {
            if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
            {
                movement = new Vector3(horizontalInput, 0.0f, 0.0f).normalized;
            }
            else
            {
                movement = new Vector3(0.0f, 0.0f, verticalInput).normalized;
            }
        }
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
