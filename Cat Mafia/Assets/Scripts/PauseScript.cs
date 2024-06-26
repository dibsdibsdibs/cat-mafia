using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [Header("Pause Manager")]
    public GameObject pauseScreen;
    [SerializeField] public Button titleButton;
    [SerializeField] public Button continueButton;
    [SerializeField] public Button quitButton;
    [SerializeField] private int selectedButtonIndex = 0;
    [SerializeField] public Image selectionIndicator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip selectionSound;
    [SerializeField] private AudioClip finalSelectionSound;
    [SerializeField] public bool isActive = false;

    private Button[] buttons;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedButtonIndex = (selectedButtonIndex + 1) % buttons.Length;
            UpdateSelection();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedButtonIndex = (selectedButtonIndex - 1 + buttons.Length) % buttons.Length;
            UpdateSelection();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            ExecuteOption();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isActive = pauseScreen.activeSelf;

        if (isActive)
        {
            buttons = new Button[] { continueButton, titleButton, quitButton };
            continueButton.Select();
            UpdateIndicatorPosition(continueButton);
        }
    }

    void UpdateSelection()
    {
        PlaySelectionSound();
        buttons[selectedButtonIndex].Select();
        UpdateIndicatorPosition(buttons[selectedButtonIndex]);
    }

    void UpdateIndicatorPosition(Button button)
    {
        selectionIndicator.transform.position = new Vector3(button.transform.position.x - 200f, button.transform.position.y, button.transform.position.z);
    }

    void ExecuteOption()
    {
        isActive = false;
        PlayFinalSelectionSound();
        if (selectedButtonIndex == 0)
        {
            Debug.Log("Continue Game");
            pauseScreen.SetActive(false);
        }
        else if (selectedButtonIndex == 1)
        {
            Debug.Log("Go to Title Screen");
            SceneManager.LoadScene("MenuScreen");
        }
        else if (selectedButtonIndex == 2)
        {
            Debug.Log("Quit Game!");
            Application.Quit();
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

    public bool isPauseActivated()
    {
        return isActive;
    }
}
