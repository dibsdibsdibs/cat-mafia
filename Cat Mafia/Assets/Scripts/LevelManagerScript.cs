using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float totalTime;
    [SerializeField] GameObject foodBar;
    private FoodBarScript foodBarScript;

    void Start()
    {
        foodBarScript = foodBar.GetComponent<FoodBarScript>();
    }

    void Update()
    {
        if (totalTime > 0){
            totalTime -= Time.deltaTime;
        }
        else if(totalTime < 0){
            totalTime = 0;
        }
  
        float seconds = Mathf.FloorToInt(totalTime % 60);
        timeText.text = string.Format("Time: {0:00}", seconds);
    }
    public void UpdateBar(float itemValue)
    {
        foodBarScript.UpdateBar(itemValue);
        Debug.Log("Food bar value updated");
    }
}
