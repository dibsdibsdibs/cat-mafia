using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerController : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        // execute the moving animation
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
        
}
