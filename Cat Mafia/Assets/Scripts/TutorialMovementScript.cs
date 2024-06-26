using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMovementScript : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float movementSpeed = 5;
    private Rigidbody2D rb;
    public LayerMask groundLayer;
    private BoxCollider2D boxCollider;
    public GameObject pauseScreen;
    private PauseScript pauseManager;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        pauseManager = pauseScreen.GetComponent<PauseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isPauseActive = pauseScreen.activeSelf;

        if(isPauseActive == false)
        {
            if(!(Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)){
                if(Input.GetAxis("Horizontal") > 0){
                    MoveRight();
                }
                if(Input.GetAxis("Horizontal") < 0){
                    MoveLeft();
                }
                if(Input.GetAxis("Vertical") > 0){
                    MoveUp();
                }
                if(Input.GetAxis("Vertical") < 0){
                    MoveDown();
                }
            }
        }
        // prevent horizontal movement

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            animator.SetFloat("moveX", -1f);
            animator.SetFloat("moveY", 0);
            OnIsMoving();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            animator.SetFloat("moveX", 1f);
            animator.SetFloat("moveY", 0);
            OnIsMoving();
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            animator.SetFloat("moveX", 0);
            animator.SetFloat("moveY", -1f);
            OnIsMoving();
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            animator.SetFloat("moveX", 0);
            animator.SetFloat("moveY", 1f);
            OnIsMoving();
        }
        if(Input.GetKeyDown(KeyCode.DownArrow) 
        || Input.GetKeyDown(KeyCode.UpArrow) 
        || Input.GetKeyDown(KeyCode.LeftArrow) 
        || Input.GetKeyDown(KeyCode.RightArrow)){
            OffIsMoving();
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, boxCollider.bounds.extents.y + 0.1f, groundLayer);
        if (hit.collider != null)
        {
            float distanceToGround = hit.distance - boxCollider.bounds.extents.y;
            rb.position += Vector2.down * distanceToGround;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }

        if(Input.GetKey(KeyCode.X))
        {
            pauseScreen.SetActive(true);
            pauseManager.TogglePause();
        }
    }
    public void OffIsMoving(){
        animator.SetBool("isMoving", false);
    }
    public void OnIsMoving(){
        animator.SetBool("isMoving", true);
    }
    // experimental
    // change accordingly
    private void MoveRight(){
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    }
    private void MoveLeft(){
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
    }
    private void MoveDown(){
        transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);

    }
    private void MoveUp(){
        transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
    }
}
