using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInteractItemScript : MonoBehaviour
{
    [SerializeField] public string itemName;
    [SerializeField] public bool isPlayerInRange = false;
    [SerializeField] public bool pickedUpItem = false;
    private TutorialScreenManager tutorialManager;
    [SerializeField] public GameObject food;

    void Start()
    {
        tutorialManager = GameObject.Find("TutorialManager").GetComponent<TutorialScreenManager>();
    }

    void Update()
    {
        if(tutorialManager.activateFood)
        {
            food.SetActive(true);
            Debug.Log(tutorialManager.activateFood);
        }

        if (tutorialManager.activateFood && isPlayerInRange && Input.GetKeyDown(KeyCode.Z))
        {
            Interact();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    void Interact()
    {
        pickedUpItem = true;
        Debug.Log("Picked up " + itemName);
        tutorialManager.UpdatePickUp(pickedUpItem);
        Destroy(gameObject);
    }
}
