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
    
    // collider manager
    private BoxColliderManager boxColliderManager;

    // movement variables
    private Vector2 movement;

    // keeps track of the direction where the cat is facing
    // necessary for the implementatino of dash
    private Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        // manages the vertical  and horizontal box colliders
        boxColliderManager = GetComponent<BoxColliderManager>();
        pauseManager = pauseScreen.GetComponent<PauseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isPauseActive = pauseScreen.activeSelf;
        // prevents user input from affecting the character when the game is paused
        if(isPauseActive == false){
            if(Input.GetKey(KeyCode.UpArrow)){
                movement.x = 0;
                movement.y = 1;
                ChangeDirection();
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                movement.x = 0;
                movement.y = -1;
                ChangeDirection();
            }
            if(Input.GetKey(KeyCode.LeftArrow)){
                movement.y = 0;
                movement.x = -1;
                ChangeDirection();
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                movement.y = 0;
                movement.x = 1;
                ChangeDirection();
            }
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow)
        ||Input.GetKeyUp(KeyCode.RightArrow)
        ||Input.GetKeyUp(KeyCode.UpArrow)
        ||Input.GetKeyUp(KeyCode.DownArrow)
        ){
            movement = Vector2.zero;
            SetIsNotMoving();
        }
        
        // i guess this is for collision only?
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

    void FixedUpdate(){
        Move();
    }

    // moving animation
    private void SetIsMoving(){
        animator.SetBool("isMoving", true);
    }
    // idle animation
    private void SetIsNotMoving(){
        animator.SetBool("isMoving", false);
    }
    // replaced translate with rigidbody.moveposition
    private void Move(){
        rb.MovePosition(rb.position + movement * movementSpeed * Time.deltaTime);
    }
    // changes the direction where the character is facing
    // dependent on the input
    private void ChangeDirection () {
        // keeps track of the direction where the character is facing
        direction = movement;
        // sets up the vertical movement box collider
        if(direction.y > 0){
            boxColliderManager.SetUpBoxCollider();
        }else if(direction.y < 0){
            boxColliderManager.SetDownBoxCollider();
        }
        // sets up the horizontal movement collider
        if(direction.x > 0){
            boxColliderManager.SetRightBoxCollider();
        }else if(direction.x < 0){
            boxColliderManager.SetLeftBoxCollider();
        }
        // turns on animation based on user input
        animator.SetFloat("moveX", movement.x);
        animator.SetFloat("moveY", movement.y);
        // enables the movement animation
        SetIsMoving();
    }
}
