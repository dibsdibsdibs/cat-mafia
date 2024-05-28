using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] food;
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
        GameObject randomFood = food[Random.Range(0, food.Length)];
        Instantiate(randomFood, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(1f, 3f));
    }
}
