using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cat2Ending : MonoBehaviour
{
    private Animator animator;
    public Vector3 targetPosition; 
    public Vector3 startPosition; 
    public DialogueManager star3Dialogue;
    public DialogueManager star2Dialogue;
    public DialogueManager star1Dialogue;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public bool isInPosition;
    public bool isDone = false;
    public float speed = 2f;
    public AudioSource audioSource;
    public AudioClip starDisp;
    public int starRating;
    // Start is called before the first frame update
    void Start()
    {
    
        animator = GetComponent<Animator>();
        starRating = StarRating.Rating;
        isInPosition = false;
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInPosition)
        {
            animator.SetFloat("moveX", 1f);
            animator.SetFloat("moveY", 0);
            animator.SetBool("isMoving", true);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                OffIsMoving();
                transform.position = targetPosition;
                PlayAudio(starDisp);
                
                if (starRating == 1)
                {
                    star1.SetActive(true);
                    StartCoroutine(Star1Finished()); 
                }

                else if (starRating == 2)
                {
                    star2.SetActive(true);
                    StartCoroutine(Star2Finished()); 
                }

                else
                {
                    star3.SetActive(true); 
                    StartCoroutine(Star3Finished()); 
                }
            }
        }
        if (isDone)
        {
            Invoke("NextScene", starDisp.length);
        }
    }
           
    
    IEnumerator Star1Finished()
    {
        yield return new WaitUntil(() => star1Dialogue.IsDialogueFinished());
        isDone = true;
     
    }
    IEnumerator Star2Finished()
    {
        yield return new WaitUntil(() => star2Dialogue.IsDialogueFinished());
        isDone = true;
     
    }
    IEnumerator Star3Finished()
    {
        yield return new WaitUntil(() => star3Dialogue.IsDialogueFinished());
        isDone = true;
     
    }
    private void NextScene()
    {
        SceneManager.LoadScene("Cat2Dialogue");
    }
    public void OffIsMoving(){
        animator.SetBool("isMoving", false);
    }
    void PlayAudio(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
}

