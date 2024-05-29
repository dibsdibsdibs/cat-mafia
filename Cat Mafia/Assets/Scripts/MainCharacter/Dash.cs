using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    // Start is called before the first frame update

    private bool isDashing;
    private bool canDash;
    private Rigidbody2D rb;

    [SerializeField] private float dashSpeed = 15;

    [SerializeField] private float dashDuration = 5f;

    [SerializeField] private float dashCooldown = 7;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void characterDash(Vector2 direction){
        if(canDash){
            StartCoroutine(PerformDash(direction));
        }
    }

    private IEnumerator PerformDash (Vector2 direction) {
        canDash = false;
        rb.velocity = direction * dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
