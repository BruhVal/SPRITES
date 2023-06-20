using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;


public class playermovement : MonoBehaviour
{
    //Variable for our speed modifier 
    public float moveSpeed;

    //variable for our input
    public Vector2 movementInput;

    //Variable For our rigitbody2d
    public Rigidbody2D rigidBody;

    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("KnightForward");
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("KnightBackward");
        }
    }

    //Handles physics
    private void FixedUpdate()
    {
        //adds a velocity on our rigidbody
        rigidBody.velocity = movementInput * moveSpeed;
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }



}