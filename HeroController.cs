using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    private float movementInputDirection;
    private bool isFacingRight = true;

    private Rigidbody2D rb;
    public float movementSpeed = 10.0f;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void CheckMovementDirection() 
    {
        if(isFacingRight && movementInputDirection < 0) 
        {
            Flip();
        
        }
        else if(isFacingRight && movementInputDirection > 0) 
        {
            Flip();
        
        }
    
    }
    private void CheckInput() 
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");
    
    }

    private void ApplyMovement() 
    {
        rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
    }

    private void Flip() 
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    
    }
}

