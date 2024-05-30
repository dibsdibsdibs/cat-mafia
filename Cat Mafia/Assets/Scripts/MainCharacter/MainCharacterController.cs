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
    private Vector2 movement;
    private Vector2 direction;

    public GameObject failedScreen;
    public GameObject levelManager;
    public LevelManagerScript levelScript;

    // dash variables
    [SerializeField] private float dashSpeed = 20;

    [SerializeField] private float dashDuration = 0.1f;

    [SerializeField] private float dashCooldown = 7;
    private bool isDashing = false;
    private bool canDash = true;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        pauseManager = pauseScreen.GetComponent<PauseScript>();
        levelScript = levelManager.GetComponent<LevelManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isPauseActive = pauseScreen.activeSelf;
        bool isFailedActive = failedScreen.activeSelf;
        
        if(isPauseActive == false && isFailedActive == false)
        {
        if(Input.GetKey(KeyCode.UpArrow)){
            MoveUp();
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            MoveDown();
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            MoveLeft();
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            MoveRight();
        }

        if(Input.GetKeyUp(KeyCode.LeftArrow)
        ||Input.GetKeyUp(KeyCode.RightArrow)
        ||Input.GetKeyUp(KeyCode.UpArrow)
        ||Input.GetKeyUp(KeyCode.DownArrow)
        ){
            movement = Vector2.zero;
            SetIsNotMoving();
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            if(canDash){
                isDashing = true;
                StartCoroutine(PerformDash());
            }
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, boxCollider.bounds.extents.y + 0.1f, groundLayer);
        if (hit.collider != null)
        {
            float distanceToGround = hit.distance - boxCollider.bounds.extents.y;
            rb.position += Vector2.down * distanceToGround;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
    
        }
    }

    void FixedUpdate(){
        if(!isDashing){
            Move();
        }
    }

    private void MoveUp(){
        movement.x = 0;
        movement.y = 1;
        ChangeDirection();
    }

    private void MoveDown(){
        movement.x = 0;
        movement.y = -1;
        ChangeDirection();
    }

    private void MoveRight(){
        movement.y = 0;
        movement.x = 1;
        ChangeDirection();
    }

    private void MoveLeft(){
        movement.y = 0;
        movement.x = -1;
        ChangeDirection();
    }

    private void ChangeDirection () {
        direction = movement;
        animator.SetFloat("moveX", movement.x);
        animator.SetFloat("moveY", movement.y);
        SetIsMoving();
    }

    private void SetIsMoving(){
        animator.SetBool("isMoving", true);
    }

    private void SetIsNotMoving(){
        animator.SetBool("isMoving", false);
    }

    private void Move(){
        rb.MovePosition(rb.position + movement * movementSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Owner"))
        {
            Debug.Log("Entered here");
            levelScript.FailedLevel();
        }
    }
    private IEnumerator PerformDash () {
        canDash = false;
        rb.velocity = direction * dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
