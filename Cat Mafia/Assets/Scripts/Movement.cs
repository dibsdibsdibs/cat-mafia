using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    private void FixedUpdate()
    {
        rb.MovePosition (rb.position + movement *Time.fixedDeltaTime);
    }
}
