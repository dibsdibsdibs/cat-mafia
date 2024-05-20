using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderManager : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    // box collider offset and size when the character is facing downward
    private float downBoxColliderOffsetX = -0.006385282f;
    private float downBoxColliderOffsetY = 0.1718912f;
    private float downBoxColliderHeight = 0.286882f;
    private float downBoxColliderWidth = 0.1224317f;
    // box collider size and offset when the character is facing left
    private float leftBoxColliderOffsetX = -0.01012085f;
    private float leftBoxColliderOffsetY = 0.1207144f;
    private float leftBoxColliderHeight = 0.1845401f;
    private float leftBoxColliderWidth = 0.2366247f;
    // box collider size and offset when the character is facing right
    private float rightBoxColliderOffsetX =0.01432367f;
    private float rightBoxColliderOffsetY = 0.1287867f;
    private float rightBoxColliderHeight = 0.2006848f;
    private float rightBoxColliderWidth = 0.2425977f;
    // box collider size and offset when the character is facing up
    private float upBoxColliderOffsetX =-0.009146318f;
    private float upBoxColliderOffsetY = 0.1570782f;
    private float upBoxColliderHeight = 0.2572678f;
    private float upBoxColliderWidth = 0.1365683f;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // character faces left collider
    public void SetLeftBoxCollider () {
        boxCollider2D.offset = new Vector2(leftBoxColliderOffsetX, leftBoxColliderOffsetY);
        boxCollider2D.size = new Vector2(leftBoxColliderWidth, leftBoxColliderHeight);
    }
    // character faces right collider
    public void SetRightBoxCollider () {
        boxCollider2D.offset = new Vector2(rightBoxColliderOffsetX, rightBoxColliderOffsetY);
        boxCollider2D.size = new Vector2(rightBoxColliderWidth, rightBoxColliderHeight);
    }
    // character faces up collider
    public void SetUpBoxCollider(){
        boxCollider2D.offset = new Vector2(upBoxColliderOffsetX, upBoxColliderOffsetY);
        boxCollider2D.size = new Vector2(upBoxColliderWidth, upBoxColliderHeight);
    }
    // character faces down collider
    public void SetDownBoxCollider(){
        boxCollider2D.offset = new Vector2(downBoxColliderOffsetX, downBoxColliderOffsetY);
        boxCollider2D.size = new Vector2(downBoxColliderWidth, downBoxColliderHeight);
    }
}
