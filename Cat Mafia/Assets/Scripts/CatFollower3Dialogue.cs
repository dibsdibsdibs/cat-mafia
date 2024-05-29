using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatFollower3Dialogue : MonoBehaviour
{
   
    public Vector3 finalTargetPosition;
    public Vector3 startPosition; 
    public GameObject Cat3Dialogue;
    public bool isDone;
    public DialogueManager checkDialogue;
    public float speed = 2f;
    [SerializeField] public string nextScene;

    void Start()
    {   
      
        Cat3Dialogue.SetActive(false); 
        checkDialogue = Cat3Dialogue.GetComponent<DialogueManager>();
        transform.position =  startPosition;
       
    }

    void Update()
    {
        Cat3Dialogue.SetActive(true);
      
        transform.position = Vector3.MoveTowards(transform.position, finalTargetPosition, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, finalTargetPosition) < 0.01f)
        {
           
            transform.position = finalTargetPosition;
        }
    
        if (checkDialogue.IsDialogueFinished())
        {
            Cat3Dialogue.SetActive(false);
            Invoke("NextScene", 1.0f);
        }
    }

    private void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}