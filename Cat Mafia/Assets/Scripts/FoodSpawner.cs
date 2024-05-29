using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] treats;
    public Transform[] foodLoc;
    public int spawnRate = 10;
    public int spawnItem;
    public bool hasSpawn = false;
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
        while (true)
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
                    GameObject randomTreat;
                    spawnItem = Random.Range(0, treats.Length);
                    if (hasSpawn == false && spawnItem == 17)
                    {
                        randomTreat = treats[17];
                        hasSpawn = true;
                    }
                    else
                    {
                        spawnItem = Random.Range(0, treats.Length);
                        if (spawnItem == 17)
                        {
                            spawnItem = (spawnItem + 1) % treats.Length;
                        }
                        randomTreat = treats[spawnItem];
                    }
                    GameObject treat = Instantiate(randomTreat, randomfoodLoc.position, Quaternion.identity);
                    treat.transform.SetParent(randomfoodLoc);
                    i += 1;

                }    
            }
            yield return new WaitForSeconds(Random.Range(5f, 8f));
        }
    }

}

