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
    [SerializeField] public GameObject foodBar;
    [SerializeField] public GameObject treasure;
    [SerializeField] private FoodBarScript foodBarScript;
    [SerializeField] private TreasureInteract treasureInteract;
    [SerializeField] public string nextScene;
    [SerializeField] public GameObject failedDialogue;
    [SerializeField] private FailedLevelScript failedManager;

    [Header("Owner")]
    [SerializeField] public GameObject ownerClone;
    [SerializeField] public Vector2 spawnPointOwner;
    public bool treasureCollected = false;

    void Start()
    {
        foodBarScript = foodBar.GetComponent<FoodBarScript>();
        failedManager = failedDialogue.GetComponent<FailedLevelScript>();
        treasureInteract = treasure.GetComponent<TreasureInteract>();
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
    public void UpdateTreasure(bool ispick)
    {
        treasureCollected = ispick;
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
            FailedLevel();
        }
    }

    private void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void FailedLevel()
    {
        failedDialogue.SetActive(true);
        failedManager.ToggleRestart();
    }

    public void SummonTheDemon()
    {
        GameObject instantiatedObject = Instantiate(ownerClone, spawnPointOwner, Quaternion.identity);
        Destroy(instantiatedObject, 7f);
    }
}
