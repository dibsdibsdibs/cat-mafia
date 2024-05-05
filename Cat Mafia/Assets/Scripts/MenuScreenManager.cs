using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreenManager : MonoBehaviour
{
    [SerializeField] public GameObject catCharacter;
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private bool moveRight = true;
    [SerializeField] private float moveDistance = 10.0f;

    [SerializeField] public Button startButton;
    [SerializeField] public Button quitButton;
    [SerializeField] private int selectedButtonIndex = 0;
    [SerializeField] public Image selectionIndicator;
    [SerializeField] private Animator catAnimator;

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
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            ExecuteOption();
        }

        MoveCatCharacter();
    }

    void MoveCatCharacter()
    {
        if (moveRight)
        {
            catCharacter.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            catCharacter.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
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
            selectionIndicator.transform.position = startButton.transform.position;
        }
        else
        {
            selectionIndicator.transform.position = quitButton.transform.position;
        }
    }

    void ExecuteOption()
    {
        if (selectedButtonIndex == 0)
        {
            Debug.Log("Start Game!");
        }
        else
        {
            Debug.Log("Quit Game!");
            Application.Quit();
        }
    }
}
