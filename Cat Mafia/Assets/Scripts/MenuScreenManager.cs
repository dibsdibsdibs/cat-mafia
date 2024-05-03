using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreenManager : MonoBehaviour
{
    [SerializeField] public GameObject catCharacter;
    public Vector3 targetPosition;
    [SerializeField] public float speed = 5f;

    void Start()
    {
        FirstScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FirstScene()
    {
        Vector3 targetPosition = catCharacter.transform.position + Vector3.right * 5f;

        StartCoroutine(MoveToTargetPosition(targetPosition));
    }

    IEnumerator MoveToTargetPosition(Vector3 targetPosition)
    {
        while (catCharacter.transform.position != targetPosition)
        {
            // Move the GameObject towards the target position
            catCharacter.transform.position = Vector3.MoveTowards(catCharacter.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}
