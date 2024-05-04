using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class QuitGame : MonoBehaviour
{
    private Button button; 
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ExitGame);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
