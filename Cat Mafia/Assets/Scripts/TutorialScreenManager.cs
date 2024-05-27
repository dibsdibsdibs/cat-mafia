using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScreenManager : MonoBehaviour
{
    [SerializeField] public GameObject catCharacter;
    private MainCharacterController characterController;
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public string nextScene;

    [Header("Movement Tutorial")]
    public bool movementTutorialFinished = false;
    public bool leftArrowPressed = false;
    public bool rightArrowPressed = false;
    public bool upArrowPressed = false;
    public bool downArrowPressed = false;

    [Header("Control Tutorial")]
    public bool controlTutorialFinished = false;
    public bool itemPickedUp = false;
    public bool zButtonPressed = false;
    public bool xButtonPressed = false;
    private PauseScript pauseManager;
    public bool checkedPause = false;
    public GameObject pauseScreen;

    [Header("Audio Clips")]
    public AudioClip[] audioClips;
    public int currentAudioIndex = 0;

    [Header("Cut Scenes")]
    public GameObject firstEventDialogue;
    public DialogueManager checkDialogue;
    public bool firstEventFinished = false;
    public GameObject blackPanel;
    public GameObject moveDialogue;
    public GameObject controlDialogue;
    public GameObject endTutorialDialogue;

    void Start()
    {
        characterController = catCharacter.GetComponent<MainCharacterController>();
        audioSource = GetComponent<AudioSource>();
        checkDialogue = firstEventDialogue.GetComponent<DialogueManager>();
        pauseManager = pauseScreen.GetComponent<PauseScript>();
        FirstEvent();
    }

    void Update()
    {   
        if(firstEventFinished)
        {
            characterController.enabled = true;
            Invoke("MovementTutorial", audioClips[1].length);
        }

        if(movementTutorialFinished && controlTutorialFinished == false)
        {
            Debug.Log("Entering control tutorial");
            // ControlTutorial();
            Invoke("ControlTutorial", 5.0f);
        }

        if(movementTutorialFinished && controlTutorialFinished)
        {
            Debug.Log("Ending tutorial");
            checkDialogue = endTutorialDialogue.GetComponent<DialogueManager>();
            // Invoke("EndTutorial", 1.0f);
        }
    }

    void PlayAudio(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }

    void FirstEvent()
    {
        PlayAudio(audioClips[0]);
        Invoke("FirstEventDialogue", audioClips[0].length);
    }

    void FirstEventDialogue()
    {
        firstEventDialogue.SetActive(true);
        StartCoroutine(CheckFirstEventDialogueFinished());
    }

    IEnumerator CheckFirstEventDialogueFinished()
    {
        yield return new WaitUntil(() => checkDialogue.IsDialogueFinished());
        firstEventFinished = true;
        PlayAudio(audioClips[1]);
    }

    void MovementTutorial()
    {
        blackPanel.SetActive(false);
        moveDialogue.SetActive(true);

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            leftArrowPressed = true;
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            rightArrowPressed = true;
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            upArrowPressed = true;
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            downArrowPressed = true;
        }

        if(leftArrowPressed && rightArrowPressed && downArrowPressed && upArrowPressed)
        {
            movementTutorialFinished = true;
            Debug.Log("Finished movement tutorial");
            moveDialogue.SetActive(false);
        }
    }

    void ControlTutorial()
    {
        controlDialogue.SetActive(true);

        if(Input.GetKey(KeyCode.Z))
        {
            if(itemPickedUp == true)
            {
                zButtonPressed = true;
            }
        }

        if(Input.GetKey(KeyCode.X) && zButtonPressed)
        {
            xButtonPressed = true;
            PauseGame();
        }

        if(zButtonPressed && checkedPause)
        {
            controlTutorialFinished = true;
            Debug.Log("Finished control tutorial");
            controlDialogue.SetActive(false);
        }
    }

    void EndTutorial()
    {
        endTutorialDialogue.SetActive(true);
        StartCoroutine(CheckEndTutorialDialogue());
    }

    IEnumerator CheckEndTutorialDialogue()
    {
        yield return new WaitUntil(() => checkDialogue.IsDialogueFinished());
        NextScene();
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
    
    private void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void UpdatePickUp(bool pickedUp)
    {
        itemPickedUp = pickedUp;
    }

    void PauseGame()
    {
        if(pauseScreen.activeSelf)
        {
            checkedPause = true;
        }
    }
}
