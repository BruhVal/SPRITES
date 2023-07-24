using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playermovement : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 movementInput;
    public Rigidbody2D rigidBody;
    public Animator anim;
    public TextMeshProUGUI coinsCounter, healthPoint;
    public int coincounter;
    public int health;
    public int trapDmg;
    public bool playerOnTop;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = movementInput * moveSpeed;
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            coincounter++;
            Destroy(collision.gameObject);
            coinsCounter.text = "Coins: " + coincounter.ToString();
        }

        if (collision.CompareTag("Player"))
        {
            playerOnTop = true;
            anim.SetBool("isActive", true);
        }

        if (collision.CompareTag("Trap"))
        {
            DamagePlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnTop = false;
            anim.SetBool("isActive", false);
        }
    }

    public void DamagePlayer()
    {
        if (playerOnTop)
        {
            playerOnTop = false;
            health -= trapDmg;
            healthPoint.text = "Health: " + health.ToString();

            Debug.Log("Player took damage. Current health: " + health);
        }
    }
}
