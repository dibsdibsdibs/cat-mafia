
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OwnerController : MonoBehaviour
{
    private Animator animator;

    public LayerMask layerMask;

    // Start is called before the first frame update
    private Vector2 direction;
    public GameObject player;
    [SerializeField] private float movementSpeed = 5;
    private float tempMovementSpeed;
    [SerializeField] private LayerMask furnitures;
    Vector3 newPosition;

    private bool isMoving = false;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();   
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate(){
        if(!isMoving){
            SetDirection();
        }
    }

    void OnCollisionStay2D(Collision2D collision){
        // check the direction where there is no colliders
        DetermineDirection();
        ChangeDirection();
        if(isMoving){
            newPosition = new Vector3(direction.x, direction.y, 0) + transform.position;
        }else{

            newPosition = new Vector3(direction.x, direction.y, 0) + transform.position;
            StartCoroutine(Move());
        }
        Invoke("SecondTurn", 0.2f);
    }

    void OnCollisionEnter2D(Collision2D collision){
        direction = direction * -1;
        ChangeDirection();
        if(isMoving){
            newPosition = new Vector3(direction.x, direction.y, 0) + transform.position;
        }else{

            newPosition = new Vector3(direction.x, direction.y, 0) + transform.position;
            StartCoroutine(Move());
        }
        Invoke("SecondTurn", 0.2f);
    }
    private void SetDirection () {
        float distanceX = player.transform.position.x - transform.position.x;
        float distanceY = player.transform.position.y - transform.position.y;
        if (Mathf.Abs(distanceX) > Mathf.Abs(distanceY))
        {
            direction = new Vector2(Mathf.Sign(distanceX), 0); // Move horizontally
        }
        else
        {
            direction= new Vector2(0, Mathf.Sign(distanceY)); // Move vertically
        }

        newPosition = new Vector3(direction.x, direction.y,0) + transform.position;
        ChangeDirection();
        StartCoroutine(Move());
        
    }
    private void ChangeDirection (){
        animator.SetFloat("moveX", direction.x);
        animator.SetFloat("moveY", direction.y);
    }

    public void OffIsMoving(){
        animator.SetBool("isMoving", false);
    }
    public void OnIsMoving(){
        animator.SetBool("isMoving", true);
    }

    IEnumerator Move(){
        isMoving = true;
        while((newPosition - transform.position).sqrMagnitude > Mathf.Epsilon){
            transform.position = Vector3.MoveTowards(transform.position, newPosition, movementSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = newPosition;
        isMoving = false;

    }

    void DetermineDirection(){
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, 0f);
        if (hitRight.collider == null || hitRight.collider.gameObject.layer == 4)
        {

            direction = Vector2.right;
            return;
        }

        // Raycast to the left
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 0f);
        if (hitLeft.collider != null|| hitRight.collider.gameObject.layer == 4)
        {
            direction = Vector2.left;
            return;
        }

        // Raycast upwards
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, 0f);
        if (hitUp.collider != null|| hitRight.collider.gameObject.layer == 4)
        {
            direction = Vector2.up;
            return;
        }

        // Raycast downwards
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down, 0f);
        if (hitDown.collider != null|| hitRight.collider.gameObject.layer == 4)
        {
            direction = Vector2.down;
            return;
        }
    }

    private void SecondTurn(){
        
        float floatIndex = Random.Range(0,2);
        int index = (int)Mathf.Floor(floatIndex);
        if(direction == Vector2.up || direction == Vector2.down){
            if(index == 1){
                direction = Vector2.left;
            }else{
                direction = Vector2.right;
            }
        }else{
            if(index == 1){
                direction = Vector2.up;
            }else{
                direction = Vector2.down;
            }
        }
        ChangeDirection();
        newPosition = new Vector3(direction.x, direction.y,0) + transform.position;
        if(!isMoving){
            StartCoroutine(Move());
        }
    }

    // charm
    public void Charm(){
        tempMovementSpeed = movementSpeed;
        movementSpeed = 0;
        StartCoroutine(StopMovement(3));
    }

    IEnumerator StopMovement(float time){
        yield return new WaitForSeconds(time);
        movementSpeed = tempMovementSpeed;

    }

}
