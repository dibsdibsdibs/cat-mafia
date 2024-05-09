using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class TutorialScreenManager : MonoBehaviour
{
    [SerializeField] public GameObject catCharacter;
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] public AudioSource audioSource;

    [Header("Movement Tutorial")]
    public bool movementTutorialFinished = false;
    public bool leftArrowPressed = false;
    public bool rightArrowPressed = false;
    public bool upArrowPressed = false;
    public bool downArrowPressed = false; 

    [Header("Control Tutorial")]
    public bool controlTutorialFinished = false;
    public bool zButtonPressed = false;
    public bool xButtonPressed = false;

    [Header("Audio Clips")]
    public AudioClip[] audioClips;

    [Header("Cut Scenes")]
    public GameObject firstEventDialogue;
    public bool firstEventFinished = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        FirstEvent();
    }

    void Update()
    {   
        if(firstEventFinished)
        {
            MovementTutorial();
            movementTutorialFinished = true;
        }

        if(movementTutorialFinished)
        {
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
        }

        // if(controlTutorialFinished == false)
        // {
        //     Debug.Log("Entering control tutorial");
        //     ControlTutorial();
        // }
    }

    void FirstEvent()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
        Invoke("FirstEventDialogue", audioClips[0].length);
    }

    void FirstEventDialogue()
    {
        firstEventDialogue.SetActive(true);
    }

    void MovementTutorial()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
            leftArrowPressed = true;
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
            rightArrowPressed = true;
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            MoveUp();
            upArrowPressed = true;
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            MoveDown();
            downArrowPressed = true;
        }

        if(leftArrowPressed && rightArrowPressed && downArrowPressed && upArrowPressed)
        {
            movementTutorialFinished = true;
            Debug.Log("Finished movement tutorial");
        }
    }

    void ControlTutorial()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            zButtonPressed = true;
        }
        if(Input.GetKey(KeyCode.X))
        {
            xButtonPressed = true;
        }

        if(zButtonPressed && xButtonPressed)
        {
            controlTutorialFinished = true;
        }
    }

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
