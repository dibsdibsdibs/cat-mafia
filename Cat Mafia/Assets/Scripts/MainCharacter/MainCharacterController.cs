using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float movementSpeed = 5;
    private Rigidbody2D rb;
    public LayerMask groundLayer;
    private BoxCollider2D boxCollider;
    public GameObject pauseScreen;
    private PauseScript pauseManager;

    // movement variables
    private Vector2 movement;
    private Vector2 direction;

    // dash
    private bool canDash = true;
    private bool isDashing = false;
    [SerializeField] private float dashSpeed = 10;
    [SerializeField] private float dashDuration = 1;
    [SerializeField] private float dashCooldown = 7;

    // scripts
    private BoxColliderManager boxColliderManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        boxColliderManager = GetComponent<BoxColliderManager>();
        pauseManager = pauseScreen.GetComponent<PauseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isPauseActive = pauseScreen.activeSelf;
        if(isPauseActive == false)
        {
            if(Input.GetKey(KeyCode.UpArrow)){
                UpMovement();
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                DownMovement();
            }
            if(Input.GetKey(KeyCode.LeftArrow)){
                LeftMovement();
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                rightMovement();
            }
            if(Input.GetKeyDown(KeyCode.Q) && canDash){
                StartCoroutine(Dash());
            }

            if(Input.GetKeyUp(KeyCode.LeftArrow)
            ||Input.GetKeyUp(KeyCode.RightArrow)
            ||Input.GetKeyUp(KeyCode.UpArrow)
            ||Input.GetKeyUp(KeyCode.DownArrow)
            ){
                movement = Vector2.zero;
                SetIsNotMoving();
            }
        }

        // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, boxCollider.bounds.extents.y + 0.1f, groundLayer);
        // if (hit.collider != null)
        // {
        //     float distanceToGround = hit.distance - boxCollider.bounds.extents.y;
        //     rb.position += Vector2.down * distanceToGround;
        //     rb.velocity = new Vector2(rb.velocity.x, 0f);
        // }

        if(Input.GetKey(KeyCode.X))
        {
            pauseScreen.SetActive(true);
            pauseManager.TogglePause();
        }
    }
    // renders movement on a definite number of frames
    void FixedUpdate(){
        if(!isDashing){
            Move();
        }
    }
    // arrow movements
    private void LeftMovement(){
        boxColliderManager.UseLeftCollider();
        movement.y = 0;
        movement.x = -1;
        ChangeDirection();
    }

    private void rightMovement(){
        boxColliderManager.UseRightCollider();
        movement.y = 0;
        movement.x = 1;
        ChangeDirection();
    }

    private void DownMovement(){
        movement.x = 0;
        movement.y = -1;
        boxColliderManager.UseDownCollider();
        ChangeDirection();
    }

    private void UpMovement(){
        movement.x = 0;
        movement.y = 1;
        boxColliderManager.UseUpCollider();
        ChangeDirection();
    }
    // sets the direction where the character faces
    private void ChangeDirection () {
        direction = movement;
        animator.SetFloat("moveX", movement.x);
        animator.SetFloat("moveY", movement.y);
        SetIsMoving();
    }
    // walking animation 
    // can be in another script for animation
    private void SetIsMoving(){
        animator.SetBool("isMoving", true);
    }

    private void SetIsNotMoving(){
        animator.SetBool("isMoving", false);
    }
    // performs a translation like movement
    private void Move(){
        rb.MovePosition(rb.position + movement * movementSpeed * Time.deltaTime);
    }
    // perform dash
    private IEnumerator Dash () {
        isDashing = true;
        canDash = false;
        rb.velocity = direction * dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

}
