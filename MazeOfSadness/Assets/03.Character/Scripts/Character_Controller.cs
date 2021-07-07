using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    // Variables for moving
    private Rigidbody2D rb;
    Vector2 movement;
    private int key;
    public float moveSpeed = 5f;

    // Variables for dashing
    public float dashSpeed = 20f;
    private bool isDashing = false;
    private bool canDash = true;

    Animator animator;

    public int health = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        if (Input.GetKeyDown(KeyCode.X) && canDash == true)
        { 
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        if (isDashing != true)
        {
            rb.velocity = movement * moveSpeed;
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;
        rb.AddForce(movement * 4f, ForceMode2D.Impulse);
        animator.SetBool("isDashing", true);
        yield return new WaitForSeconds(0.25f);
        isDashing = false;
        animator.SetBool("isDashing", false);
        yield return new WaitForSeconds(1f);
        canDash = true;
    }
}
