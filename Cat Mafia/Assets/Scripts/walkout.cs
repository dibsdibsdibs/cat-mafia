using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkout : MonoBehaviour
{
    [SerializeField] public float speed = 2.0f;
    [SerializeField] private Vector3 targetPosition; 
    [SerializeField] private Vector3 startPosition; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
