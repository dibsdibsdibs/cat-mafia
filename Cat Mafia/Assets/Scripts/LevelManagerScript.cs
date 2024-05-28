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
    [SerializeField] private Slider slider;
    [SerializeField] public float sliderValue;
    void Start()
    {
        slider = foodBar.GetComponent<Slider>();
        slider.value = sliderValue;
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
    void UpdateBar(float itemValue)
    {
        sliderValue = slider.value + itemValue;
        Debug.Log("Food bar value updated");
    }
}
