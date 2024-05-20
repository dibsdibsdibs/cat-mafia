using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CatFollower1Dialogue : MonoBehaviour
{
    public TextMeshProUGUI interactText;
    public Vector3 targetPosition; 
    public Vector3 startPosition; 
    public GameObject Cat1Dialogue;
    public bool isDone;
    public DialogueManager checkDialogue;
    public float speed = 2f;

    void Start()
    {   
    
        Cat1Dialogue.SetActive(false); 
        checkDialogue = Cat1Dialogue.GetComponent<DialogueManager>();
        transform.position = startPosition;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            Cat1Dialogue.SetActive(true);
        }

        if (isDone)
        {
            Cat1Dialogue.SetActive(false); 
        }
    }
}