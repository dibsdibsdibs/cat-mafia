using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] treats;
    public Transform[] foodLoc;
    public int spawnRate = 5;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFood());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnFood()
    {
        int i = 0;
        while (i < spawnRate)
        {
            Transform randomfoodLoc = foodLoc[Random.Range(0, foodLoc.Length)];
            if (randomfoodLoc.childCount != 0)
            {        
                yield return null;
            }
            else
            {
                GameObject randomTreat = treats[Random.Range(0, treats.Length)];
                GameObject treat = Instantiate(randomTreat, randomfoodLoc.position, Quaternion.identity);
                treat.transform.SetParent(randomfoodLoc);
                i += 1;

            }    
        }
        yield return new WaitForSeconds(Random.Range(3f, 5f));
    }
}
