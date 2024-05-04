using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuitGame : MonoBehaviour
{
    void Start()
    {
        Button btn = GetComponentInChildren<Button>();
        btn.onClick.AddListener(ExitGame);
    }
    public void ExitGame()
    {
        Debug.Log("Button clicked");
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
