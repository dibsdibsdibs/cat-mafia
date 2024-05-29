using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatFollower1Dialogue : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] public Vector3 targetPosition; 
    [SerializeField] public Vector3 finalTargetPosition;
    [SerializeField] public Vector3 startPosition; 
    [SerializeField] public GameObject Cat1Dialogue;
    [SerializeField] public bool isDone;
    [SerializeField] public bool isInPosition;
    [SerializeField] public DialogueManager checkDialogue;
    [SerializeField] public float speed = 2f;
    [SerializeField] public string nextScene;

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

        if (checkDialogue.IsDialogueFinished())
        {
            Cat1Dialogue.SetActive(false);
            Invoke("NextScene", 1.0f);
        }
    }
    public void OffIsMoving(){
        animator.SetBool("isMoving", false);
    }
    
    void DisableMovement()
    {
        animator.enabled = false;
    }

    private void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}