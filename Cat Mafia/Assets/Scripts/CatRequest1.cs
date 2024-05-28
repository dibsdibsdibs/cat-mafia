using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CatRequest1 : MonoBehaviour
{
    public Vector3 targetPosition; 

    public Vector3 finalTargetPosition;
    public Vector3 startPosition; 
    public GameObject Cat2Dialogue;
    public bool isDone;
    public bool isInPosition;

    public DialogueManager checkDialogue;
    public float speed = 2f;

    void Start()
    {   

        Cat2Dialogue.SetActive(true); 
        checkDialogue = Cat2Dialogue.GetComponent<DialogueManager>();
        transform.position =  startPosition;
        isInPosition = false;
  
    }

    void Update()
    {

            
        
    }

}