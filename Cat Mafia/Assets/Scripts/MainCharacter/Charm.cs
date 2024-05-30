using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charm : MonoBehaviour
{

    private int count = 0;
    [SerializeField] private int cooldown = 15;
    [SerializeField] private GameObject heart;
    [SerializeField] private int maxUse = 2;
     private GameObject enemy;
    private Rigidbody2D rb;

    private bool canCharm = true;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Owner");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    public void ActivateCharm() {
        if(maxUse > count && canCharm){
            if(enemy){
                enemy.SendMessage("Charm");
            }
            StartCoroutine(PlayCharm());
            count++;
        }
    }

    IEnumerator PlayCharm(){
        canCharm = false;
        GameObject tempHeart = Instantiate(heart, transform.position + new Vector3(0, 0.5f,0), Quaternion.identity);
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        yield return new WaitForSeconds(0.5f);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        Destroy(tempHeart);
        yield return new WaitForSeconds(cooldown);
        canCharm = true;
    }
}
