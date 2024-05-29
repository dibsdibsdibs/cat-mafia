using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LivingRoomIntroSceneScript : MonoBehaviour
{
    [SerializeField] public GameObject blackPanel;
    [SerializeField] public DialogueManager currDialogueManager;

    [Header("First Dialogue")]
    [SerializeField] public bool firstDialogueFinished;
    [SerializeField] public GameObject firstDialogue;

    [Header("Second Dialogue")]
    [SerializeField] public bool secondDialogueFinished;
    [SerializeField] public GameObject secondDialogue;
    [SerializeField] public string nextScene;

    void Start()
    {
        currDialogueManager = firstDialogue.GetComponent<DialogueManager>();
        FirstDialogue();
    }

    void Update()
    {
        if(firstDialogueFinished && secondDialogueFinished == false)
        {
            blackPanel.SetActive(false);
            Invoke("SecondDialogue", 1.0f);
        }

        if(secondDialogueFinished)
        {
            NextScene();
        }
    }

    void FirstDialogue()
    {
        firstDialogue.SetActive(true);
        StartCoroutine(CheckFirstEventDialogueFinished());
    }

    IEnumerator CheckFirstEventDialogueFinished()
    {
        yield return new WaitUntil(() => currDialogueManager.IsDialogueFinished());
        firstDialogueFinished = true;
        firstDialogue.SetActive(false);
    }

    void SecondDialogue()
    {
        currDialogueManager = secondDialogue.GetComponent<DialogueManager>();
        secondDialogue.SetActive(true);
        StartCoroutine(CheckSecondEventDialogueFinished());
    }

    IEnumerator CheckSecondEventDialogueFinished()
    {
        yield return new WaitUntil(() => currDialogueManager.IsDialogueFinished());
        secondDialogueFinished = true;
    }
    private void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
