using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public Transform[] treasureLoc; 
    public GameObject treasures;
    //public bool hasSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (hasSpawned == false)
        //{
        Transform randomtreasureLoc = treasureLoc[Random.Range(0, treasureLoc.Length)];
        Instantiate(treasures, randomtreasureLoc.position, Quaternion.identity);
        //hasSpawned = true;
        //}
    }

    public void SpawnTreasure()
    {
        
    }
         


}
