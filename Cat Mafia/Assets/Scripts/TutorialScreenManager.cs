using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScreenManager : MonoBehaviour
{
    [SerializeField] public GameObject catCharacter;
    private MainCharacterController characterController;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public string nextScene;

    [Header("Movement Tutorial")]
    public bool movementTutorialFinished = false;
    public bool leftArrowPressed = false;
    public bool rightArrowPressed = false;
    public bool upArrowPressed = false;
    public bool downArrowPressed = false;

    [Header("Control Tutorial")]
    public bool pickupTutorialFinished = false;
    public bool itemPickedUp = false;
    public bool zButtonPressed = false;
    public bool xButtonPressed = false;
    private PauseScript pauseManager;
    public bool checkedPause = false;
    public GameObject pauseScreen;
    public GameObject foodItem;
    public bool checkPauseTutorialFinished = false;

    [Header("Audio Clips")]
    public AudioClip[] audioClips;
    public int currentAudioIndex = 0;
    public GameObject backgroundMusicSource;

    [Header("Cut Scenes")]
    public GameObject firstEventDialogue;
    public DialogueManager checkDialogue;
    public bool firstEventFinished = false;
    public GameObject blackPanel;
    public GameObject moveDialogue;
    public GameObject pickUpTutorialDialogue;
    public GameObject checkPauseDialogue;
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
            Invoke("PlayBGM", audioClips[1].length);
            Invoke("MovementTutorial", audioClips[1].length);
        }

        if(movementTutorialFinished && pickupTutorialFinished == false)
        {
            Debug.Log("Entering control tutorial");
            Invoke("PickUpTutorial", 3.0f);
        }

        if(pickupTutorialFinished)
        {
            Debug.Log("Entering pause tutorial");
            Invoke("CheckPauseTutorial", 3.0f);
        }

        if(movementTutorialFinished && pickupTutorialFinished && checkPauseTutorialFinished)
        {
            Debug.Log("Ending tutorial");
            checkDialogue = endTutorialDialogue.GetComponent<DialogueManager>();
            Invoke("EndTutorial", 1.0f);
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

        characterController.enabled = true;
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

    void PickUpTutorial()
    {
        pickUpTutorialDialogue.SetActive(true);
        foodItem.SetActive(true);

        if(Input.GetKey(KeyCode.Z))
        {
            if(itemPickedUp == true)
            {
                PlayAudio(audioClips[2]);
                zButtonPressed = true;
            }
        }

        if(zButtonPressed && itemPickedUp)
        {
            foodItem.SetActive(false);
            pickUpTutorialDialogue.SetActive(false);
            pickupTutorialFinished = true;
            Debug.Log("Finished control tutorial");
        }
    }

    void CheckPauseTutorial()
    {
        checkPauseDialogue.SetActive(true);

        if(Input.GetKey(KeyCode.X) && zButtonPressed)
        {
            xButtonPressed = true;
            PauseGame();
        }

        if(checkedPause)
        {
            checkPauseDialogue.SetActive(false);
            checkPauseTutorialFinished = true;
            Debug.Log("Finished control tutorial");
        }
    }

    void EndTutorial()
    {
        characterController.enabled = false;
        endTutorialDialogue.SetActive(true);
        StartCoroutine(CheckEndTutorialDialogue());
    }

    IEnumerator CheckEndTutorialDialogue()
    {
        yield return new WaitUntil(() => checkDialogue.IsDialogueFinished());
        NextScene();
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

    void PlayBGM()
    {
        backgroundMusicSource.SetActive(true);
    }
}
