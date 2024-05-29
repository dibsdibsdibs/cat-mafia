using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charm : MonoBehaviour
{

    [SerializeField] private int count = 0;
    [SerializeField] private int cooldown = 15;
    [SerializeField] private GameObject heart;
    [SerializeField] private int maxUse = 2;
    [SerializeField] private GameObject enemy;
    private Rigidbody2D rb;
    private bool canCharm = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            Debug.Log("pressed");
            ActivateCharm();
        }
    }

    private void ActivateCharm() {
        if(canCharm && maxUse > count){
            if(enemy){
                enemy.SendMessage("Charm");
            }
            StartCoroutine(PlayCharm());
            count++;
        }
    }

    IEnumerator PlayCharm(){
        GameObject tempHeart = Instantiate(heart, transform.position + new Vector3(0, 0.5f,0), Quaternion.identity);
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        canCharm = false;
        yield return new WaitForSeconds(1);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        Destroy(tempHeart);
        yield return new WaitForSeconds(cooldown);
        canCharm = true;
    }
}
