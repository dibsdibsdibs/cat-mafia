using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatFollower1Dialogue : MonoBehaviour
{
    public TextMeshProUGUI interactText;
    public Vector3 targetPosition; 
    public GameObject Cat1Dialogue;
    public float margin = 1f;
    public bool isDone;
    private bool isInPosition;
    public DialogueManager checkDialogue;

    void Start()
    {   
        interactText.enabled = false;
        Cat1Dialogue.SetActive(false); 
        checkDialogue = Cat1Dialogue.GetComponent<DialogueManager>();
        isInPosition = false;
    }

    void Update()
    {
        if (!isInPosition && Vector3.Distance(transform.position, targetPosition) < margin)
        {
            isInPosition = true;
            interactText.enabled = true;
        }

        if (isInPosition && Input.GetKeyDown(KeyCode.Z))
        {
            interactText.enabled = false; 
            Cat1Dialogue.SetActive(true);
        }

        if (isDone)
        {
            Cat1Dialogue.SetActive(false); 
            isDone = false;
            isInPosition = false;
        }
    }
}