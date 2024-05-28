using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableSpawn : MonoBehaviour
{
    public GameObject[] breakable;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBreakable());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnBreakable()
    {
        GameObject randomBreakable = breakable[Random.Range(0, breakable.Length)];
        Instantiate(randomBreakable, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(1f, 3f));
    }
}
