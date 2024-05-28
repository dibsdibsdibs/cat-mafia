using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Numerics;

public class MenuScreenManager : MonoBehaviour
{
    [Header("Cat in the Screen")]
    [SerializeField] public GameObject catCharacter;
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private bool moveRight = true;
    [SerializeField] private float moveDistance = 10.0f;
    [SerializeField] private Animator catAnimator;

    [Header("Menu Manager")]
    [SerializeField] public string nextScene;
    [SerializeField] public Button startButton;
    [SerializeField] public Button quitButton;
    [SerializeField] private int selectedButtonIndex = 0;
    [SerializeField] public Image selectionIndicator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip selectionSound;
    [SerializeField] private AudioClip finalSelectionSound;

    void Start()
    {
        catAnimator = catCharacter.GetComponent<Animator>();
        startButton.Select();
        UpdateIndicatorPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedButtonIndex = (selectedButtonIndex == 0) ? 1 : 0;
            UpdateSelection();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedButtonIndex = (selectedButtonIndex == 1) ? 0 : 1;
            UpdateSelection();
        }
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z))
        {
            ExecuteOption();
        }

        MoveCatCharacter();
    }

    void MoveCatCharacter()
    {
        if (moveRight)
        {
            catCharacter.transform.Translate(UnityEngine.Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            catCharacter.transform.Translate(UnityEngine.Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (catCharacter.transform.position.x >= moveDistance)
        {
            moveRight = false;
            catAnimator.SetBool("Move_Left", !moveRight);
        }
        else if (catCharacter.transform.position.x <= -moveDistance)
        {
            moveRight = true;
            catAnimator.SetBool("Move_Left", !moveRight);
        }
    }

    void UpdateSelection()
    {
        PlaySelectionSound();

        if (selectedButtonIndex == 0)
        {
            startButton.Select();
        }
        else
        {
            quitButton.Select();
        }

        UpdateIndicatorPosition();
    }

    void UpdateIndicatorPosition()
    {
        if (selectedButtonIndex == 0)
        {
            selectionIndicator.transform.position = new UnityEngine.Vector3(startButton.transform.position.x-1.25f, startButton.transform.position.y, startButton.transform.position.z);
        }
        else
        {
            selectionIndicator.transform.position = new UnityEngine.Vector3(quitButton.transform.position.x-1.25f, quitButton.transform.position.y, quitButton.transform.position.z);
        }
    }

    void ExecuteOption()
    {
        PlayFinalSelectionSound();

        if (selectedButtonIndex == 0)
        {
            Debug.Log("Start Game!");
            Invoke("StartGame", finalSelectionSound.length);   
        }
        else
        {
            Debug.Log("Quit Game!");
            Invoke("QuitGame", finalSelectionSound.length);   
        }
    }

    void PlaySelectionSound()
    {
        if (audioSource != null && selectionSound != null)
        {
            audioSource.PlayOneShot(selectionSound);
        }
    }

    void PlayFinalSelectionSound()
    {
        if (audioSource != null && finalSelectionSound != null)
        {
            audioSource.PlayOneShot(finalSelectionSound);
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene(nextScene);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
