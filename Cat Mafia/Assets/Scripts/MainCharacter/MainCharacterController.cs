using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float movementSpeed = 5;
    private float xDir = 0;
    private float yDir = -1;
    private Vector2 movement;
    private Rigidbody2D characterRigidBody;
    private bool canDash = true;
    private bool isDashing = false;
    [SerializeField]private float dashingPower;
    [SerializeField]private float dashingTime;
    [SerializeField]private float dashingCooldown;
    private TrailRenderer trailRenderer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterRigidBody = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDashing){
            return;
        }
        // prevent diagonal movement
        if(!(Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)){
            movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            SetCharDirection(movement);
        }else{
            OffIsMoving();
        }
        // execute dash
        if(Input.GetKeyDown(KeyCode.Q) && canDash){
            StartCoroutine(Dash());
        }
    }
    void FixedUpdate(){
        if(isDashing){
            return;
        }
        MoveCharacter(movement);
    }
    // animates the character based on the direction it is facing
    public void SetCharDirection(Vector2 direction){
        animator.SetFloat("moveX", direction.x);
        animator.SetFloat("moveY", direction.y);
        OnIsMoving();
    }
    // turns off the walking animation
    public void OffIsMoving(){
        animator.SetBool("isMoving", false);
    }
    // turns on the walking animation
    public void OnIsMoving(){
        animator.SetBool("isMoving", true);
    }
    // moves the character based on user input
    private void MoveCharacter(Vector2 direction){
        characterRigidBody.MovePosition((Vector2)transform.position + (direction * movementSpeed * Time.deltaTime));
    }
    // perform dash
    private IEnumerator Dash(){
        canDash = false;
        isDashing = true;
        float originalGravity = characterRigidBody.gravityScale;
        characterRigidBody.gravityScale = 0f;
        characterRigidBody.velocity = new Vector2(movement.x  * dashingPower, movement.y * dashingPower);
        trailRenderer.emitting = true; 
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        characterRigidBody.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
