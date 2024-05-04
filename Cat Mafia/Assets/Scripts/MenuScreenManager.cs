using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreenManager : MonoBehaviour
{
    [SerializeField] public GameObject catCharacter;
    public Vector3 targetPosition;
    [SerializeField] public float speed = 5f;

    public Button startButton;
    public Button quitButton;
    private int selectedButtonIndex = 0;
    public Image selectionIndicator;

    void Start()
    {
        startButton.Select();
        UpdateIndicatorPosition();
        // FirstScene();
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

    void FirstScene()
    {
        Vector3 targetPosition = catCharacter.transform.position + Vector3.right * 5f;

        StartCoroutine(MoveToTargetPosition(targetPosition));
    }

    IEnumerator MoveToTargetPosition(Vector3 targetPosition)
    {
        while (catCharacter.transform.position != targetPosition)
        {
            catCharacter.transform.position = Vector3.MoveTowards(catCharacter.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}
