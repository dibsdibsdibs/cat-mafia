using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cat1Ending : MonoBehaviour
{
    private Animator animator;
    public Vector3 targetPosition; 
    public Vector3 finalTargetPosition;
    public Vector3 startPosition; 
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public bool isInPosition;
    public bool isDone;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isInPosition = false;
        isDone = false;
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        string star  = PlayerPrefs.GetString ("star", "2");  
        if (!isInPosition)
        {
            animator.SetFloat("moveX", -1f);
            animator.SetFloat("moveY", 0);
            animator.SetBool("isMoving", true);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                isInPosition = true;
            }
        }
        else
        {

            animator.SetFloat("moveX", 0);
            animator.SetFloat("moveY", 1f);
            animator.SetBool("isMoving", true);
            transform.position = Vector3.MoveTowards(transform.position, finalTargetPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, finalTargetPosition) < 0.01f)
            {
                animator.SetFloat("moveX", -1f);
                animator.SetFloat("moveY", 0);
                OffIsMoving();
                transform.position = finalTargetPosition;
                if (star == "1")
                {
                    star1.SetActive(true);             
                }

                else if (star == "2" )
                {
                    star2.SetActive(true);
                }

                else
                {
                    star3.SetActive(true);    
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
            SceneManager.LoadScene("Cat2Dialogue");
        }
    }
    public void OffIsMoving(){
        animator.SetBool("isMoving", false);
    }
}
