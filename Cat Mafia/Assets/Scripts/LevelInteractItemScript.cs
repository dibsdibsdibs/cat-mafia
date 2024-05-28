using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInteractItemScript : MonoBehaviour
{
    [SerializeField] public string itemName;
    [SerializeField] public bool isPlayerInRange = false;
    [SerializeField] public bool pickedUpItem = false;

    [SerializeField] public float itemValue;
    private LevelManagerScript levelManager;

    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManagerScript>();
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Z))
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
        Debug.Log("Item value: " + itemValue);
        levelManager.UpdateBar(itemValue);
        Destroy(gameObject);
    }
}
