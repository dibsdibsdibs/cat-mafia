using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelManagerScript : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI timeText;
    [SerializeField] float totalTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
}
