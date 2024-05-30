using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    public float creditsDuration = 20.0f; // Duration of the credits in seconds

    void Start()
    {
        StartCoroutine(WaitAndLoadMenu());
    }

    IEnumerator WaitAndLoadMenu()
    {
        yield return new WaitForSeconds(creditsDuration);
        Invoke("LoadNextScene", 5.0f);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}