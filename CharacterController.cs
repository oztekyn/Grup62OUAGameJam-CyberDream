using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private float jumpForce = 4000f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private bool Grounded;
    private bool started;
    private bool jumping;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); //caching
        _animator= GetComponent<Animator>();
        Grounded= true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(name:"space")) 
        {
        
            if (started && Grounded) 
            
            {
                _animator.SetTrigger(name: "Jump");
                Grounded= false;
                jumping= true;
                      
            }
            else 
            {
                _animator.SetBool(name: "gameStarted", value: true);
                started= true;
            
            }
        }
        
            _animator.SetBool(name: "Grounded", Grounded);
        

    }

    private void FixedUpdate()
    {
        if (started) 
        {
            _rigidbody2D.velocity= new Vector2(x:speed,_rigidbody2D.velocity.y);
        
        }
        if (jumping) 
        {
            Debug.Log(message: "jumping");
            _rigidbody2D.AddForce(new Vector2(x:0f,y:jumpForce));
            jumping= false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) 
        {
            Grounded= true;
        }
    }
}

