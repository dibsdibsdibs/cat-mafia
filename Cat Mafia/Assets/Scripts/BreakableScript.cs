using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableScript : MonoBehaviour
{
    public GameObject levelManager;
    public LevelManagerScript levelScript;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindWithTag("LevelManager");
        levelScript = levelManager.GetComponent<LevelManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entered here");
            audioSource.Play();
            Invoke("ShatterObject", 1.0f);
        }
    }

    void ShatterObject()
    {
        Destroy(gameObject);
        levelScript.SummonTheDemon();
    }
}
