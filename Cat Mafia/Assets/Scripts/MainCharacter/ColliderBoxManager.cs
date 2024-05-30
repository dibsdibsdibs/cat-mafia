using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBoxManager : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private float rightBoxColliderOffsetX = 0.01784521f;
    private float rightBoxColliderOffsetY = 0.09069036f;
    private float rightBoxColliderHeight =0.1303581f;
    private float rightBoxColliderWidth = 0.2258912f;

    private float leftBoxColliderOffsetX = 0f;
    private float leftBoxColliderOffsetY = 0.09069036f;
    private float leftBoxColliderHeight = 0.1303581f;
    private float leftBoxColliderWidth = 0.2427692f;

    private float downBoxColliderOffsetX = -0.006931029f;
    private float downBoxColliderOffsetY = 0.1144537f;
    private float downBoxColliderHeight = 0.1734594f;
    private float downBoxColliderWidth = 0.112071f;

    private float upBoxColliderOffsetX = 0.006931029f;
    private float upBoxColliderOffsetY = 0.1309454f;
    private float upBoxColliderHeight = 0.1529238f;
    private float upBoxColliderWidth = 0.112071f;


    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UseLeftCollider(){
        boxCollider2D.offset = new Vector2(leftBoxColliderOffsetX, leftBoxColliderOffsetY);
        boxCollider2D.size = new Vector2(leftBoxColliderWidth, leftBoxColliderHeight);
    }

    public void UseRightCollider(){
        boxCollider2D.offset = new Vector2(rightBoxColliderOffsetX, rightBoxColliderOffsetY);
        boxCollider2D.size = new Vector2(rightBoxColliderWidth, rightBoxColliderHeight);
    }

    public void UseUpCollider(){
        boxCollider2D.offset = new Vector2(upBoxColliderOffsetX, upBoxColliderOffsetY);
        boxCollider2D.size = new Vector2(upBoxColliderWidth, upBoxColliderHeight);
    }

    public void UseDownCollider(){
        boxCollider2D.offset = new Vector2(downBoxColliderOffsetX, downBoxColliderOffsetY);
        boxCollider2D.size = new Vector2(downBoxColliderWidth,downBoxColliderHeight);
    }
}
