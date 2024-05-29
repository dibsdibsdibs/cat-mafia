using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CatFollower1Dialogue : MonoBehaviour
{
    private Animator animator;
    public Vector3 targetPosition; 
    public Vector3 finalTargetPosition;
    public Vector3 startPosition; 
    public GameObject Cat1Dialogue;
    public bool isDone;
    public bool isInPosition;
    public DialogueManager checkDialogue;
    public float speed = 2f;

    void Start()
    {   
        animator = GetComponent<Animator>();
        Cat1Dialogue.SetActive(false); 
        checkDialogue = Cat1Dialogue.GetComponent<DialogueManager>();
        transform.position =  startPosition;
        isInPosition = false;
    }

    void Update()
    {
        if (!isInPosition)
        {
            animator.SetFloat("moveX", -1f);
            animator.SetFloat("moveY", 0);
            animator.SetBool("isMoving", true);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                isInPosition = true;
            }
        }
        else
        {

            animator.SetFloat("moveX", 0);
            animator.SetFloat("moveY", 1f);
            animator.SetBool("isMoving", true);
            transform.position = Vector3.MoveTowards(transform.position, finalTargetPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, finalTargetPosition) < 0.01f)
            {
                animator.SetFloat("moveX", -1f);
                animator.SetFloat("moveY", 0);
                OffIsMoving();
                transform.position = finalTargetPosition;
                
                Cat1Dialogue.SetActive(true);
                Invoke("DisableMovement", 1.0f);
            }
        }
        if (isDone)
        {
            Cat1Dialogue.SetActive(false); 
        }
    }
    public void OffIsMoving(){
        animator.SetBool("isMoving", false);
    }
    
    void DisableMovement()
    {
        animator.enabled = false;
    }
}