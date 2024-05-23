using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderManager : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    // down facing box colliders
    private float downBoxColliderOffsetX = -0.005527295f;
    private float downBoxColliderOffsetY = 0.1067998f;
    private float downBoxColliderSizeX = 0.1210173f;
    private float downBoxColliderSizeY = 0.1638539f;

    // left facing box colliders

    private float leftBoxColliderOffsetX = -0.009327121f;
    private float leftBoxColliderOffsetY = 0.08641972f;
    private float leftBoxColliderSizeX = 0.2260299f;
    private float leftBoxColliderSizeY = 0.1078924f;

    // right facing box collider

    private float rightBoxColliderOffsetX = 0.01450796f;
    private float rightBoxColliderOffsetY = 0.09781908f;
    private float rightBoxColliderSizeX = 0.2274178f;
    private float rightBoxColliderSizeY = 0.1099649f;

    //upward facing box collider
    private float upBoxColliderOffsetX = -0.006218188f;
    private float upBoxColliderOffsetY = 0.100928f;
    private float upBoxColliderSizeX = 0.1223992f;
    private float upBoxColliderSizeY = 0.1161828f;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void UseLeftCollider(){
        boxCollider2D.offset = new Vector2(leftBoxColliderOffsetX, leftBoxColliderOffsetY);
        boxCollider2D.size = new Vector2(leftBoxColliderSizeX,leftBoxColliderSizeY);
    }

    public void UseRightCollider(){
        boxCollider2D.offset = new Vector2(rightBoxColliderOffsetX, rightBoxColliderOffsetY);
        boxCollider2D.size = new Vector2(rightBoxColliderSizeX,rightBoxColliderSizeY);
    }

    public void UseUpCollider(){
        boxCollider2D.offset = new Vector2(upBoxColliderOffsetX, upBoxColliderOffsetY);
        boxCollider2D.size = new Vector2(upBoxColliderSizeX, upBoxColliderSizeY);
    }

    public void UseDownCollider(){
        boxCollider2D.offset = new Vector2(downBoxColliderOffsetX, downBoxColliderOffsetY);
        boxCollider2D.size = new Vector2(downBoxColliderSizeX, downBoxColliderSizeY);
    }
}
