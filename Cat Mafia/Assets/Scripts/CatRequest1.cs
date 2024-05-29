using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] public string nextScene;

    void Start()
    {   
        Cat2Dialogue.SetActive(true); 
        checkDialogue = Cat2Dialogue.GetComponent<DialogueManager>();
        transform.position =  startPosition;
        isInPosition = false;
    }

    void Update()
    {
        if (checkDialogue.IsDialogueFinished())
        {
            Invoke("NextScene", 1.0f);
        }
    }

    private void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}