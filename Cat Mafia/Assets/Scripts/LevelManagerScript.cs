using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float totalTime;
    [SerializeField] GameObject foodBar;
    [SerializeField] private FoodBarScript foodBarScript;
    [SerializeField] public bool treasureCollected = false;
    [SerializeField] public string nextScene;

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
            CheckScene();
        }
  
        float seconds = Mathf.FloorToInt(totalTime % 60);
        timeText.text = string.Format("Time: {0:00}", seconds);
    }
    public void UpdateBar(float itemValue)
    {
        foodBarScript.UpdateBar(itemValue);
        Debug.Log("Food bar value updated");
    }

    void CheckScene()
    {
        bool finishedFoodCollection = foodBarScript.FinishedFoodCollection();

        if(finishedFoodCollection || treasureCollected)
        {
            if(finishedFoodCollection && treasureCollected)
            {
                StarRating.Rating = 3;
            }else if(finishedFoodCollection == false && treasureCollected)
            {
                StarRating.Rating = 2;
            }else{
                StarRating.Rating = 1;
            }
            Debug.Log("Received value" + finishedFoodCollection);
            NextScene();
        }else{
            RestartScene();
        }
    }

    private void NextScene()
    {
        
        SceneManager.LoadScene(nextScene);
    }

    private void RestartScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
