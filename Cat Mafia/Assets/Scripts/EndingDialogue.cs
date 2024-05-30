using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingDialogue : MonoBehaviour
{
    public DialogueManager endingDialogue;
    public GameObject end;
    // Start is called before the first frame update
    void Start()
    {
        endingDialogue = end.GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        end.SetActive(true);
        if (endingDialogue.IsDialogueFinished())
        {
            SceneManager.LoadScene("EndCredits");
        }
    }
}
