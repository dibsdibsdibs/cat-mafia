using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableSpawn : MonoBehaviour
{
    public GameObject[] breakables;
    public Transform[] breakableLoc;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 5.0f);
    }
    void Spawn()
    {
        StartCoroutine(SpawnBreakable());
    }

    // Update is called once per frame
    IEnumerator SpawnBreakable()
    {
        while (true)  
        {
            for (int i = 0; i < 5; i++)
            {
                Transform randomBreakableLoc = breakableLoc[Random.Range(0, breakableLoc.Length)];
                if (randomBreakableLoc.childCount == 0)
                {
                    GameObject randomBreakable = breakables[Random.Range(0, breakables.Length)];
                    GameObject breakable = Instantiate(randomBreakable, randomBreakableLoc.position, Quaternion.identity);
                    breakable.transform.SetParent(randomBreakableLoc);
                    StartCoroutine(RemoveBreakable(breakable));
                    i += 1;
                    yield return new WaitForSeconds(Random.Range(5f, 10f)); 
                }
                yield return null; 
            }
            yield return new WaitForSeconds(Random.Range(5f, 10f));  // Wait before spawning next set of breakables
        }   
    }
    IEnumerator RemoveBreakable(GameObject breakable)
    {
        yield return new WaitForSeconds(5f); 
        Destroy(breakable);
    }
}
