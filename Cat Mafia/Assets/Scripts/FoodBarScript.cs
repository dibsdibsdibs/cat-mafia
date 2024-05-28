using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBarScript : MonoBehaviour
{
    private Slider slider;
    [SerializeField] public float sliderValue;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = sliderValue;
    }

    public void UpdateBar(float itemValue)
    {
        sliderValue = slider.value + itemValue;
        Debug.Log("Food bar value updated");
    }
}
