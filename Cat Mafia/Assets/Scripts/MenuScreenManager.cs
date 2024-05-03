using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreenManager : MonoBehaviour
{
    [SerializeField] public GameObject CatCharacter;
    [SerializeField] public Vector3 targetPosition;
    [SerializeField] public float speed = 5f;

    void Start()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
