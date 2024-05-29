using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureInteract : MonoBehaviour
{
    [SerializeField] public string itemName;
    [SerializeField] public bool isPlayerInRange = false;
    [SerializeField] public bool pickedUpItem = false;

    private LevelManagerScript levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManagerScript>();
    }

    // Update is called once per frame
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

    public void Interact()
    {
        levelManager.UpdateTreasure(true);
        Debug.Log("Picked up treasurae" + itemName);
        Destroy(gameObject);
    }
    public bool TreasureCollected()
    {
        if (pickedUpItem == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
