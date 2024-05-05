using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float movementSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // prevent horizontal movement
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
    if(Input.GetKeyDown(KeyCode.A)){
        animator.SetFloat("moveX", -1f);
        animator.SetFloat("moveY", 0);
        OnIsMoving();
    }
    if(Input.GetKeyDown(KeyCode.D)){
        animator.SetFloat("moveX", 1f);
        animator.SetFloat("moveY", 0);
        OnIsMoving();
    }
    if(Input.GetKeyDown(KeyCode.S)){
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1f);
        OnIsMoving();
    }
    if(Input.GetKeyDown(KeyCode.W)){
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", 1f);
        OnIsMoving();
    }
    if(Input.GetKeyUp(KeyCode.S)
    ||Input.GetKeyUp(KeyCode.W)
    ||Input.GetKeyUp(KeyCode.A)||
    Input.GetKeyUp(KeyCode.D)){
        OffIsMoving();
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
