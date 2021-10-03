using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;

    Vector2 movement;

    public Animator animator;

    public bool isInEnigma;
    public DialogController dialogController;
    public UserInventory inventory;

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        float charaterVelocity = Mathf.Abs(rb.velocity.x);


        //animator.SetFloat("Speed", charaterVelocity);
    }

    private void FixedUpdate()
    {
        if(!isInEnigma && !dialogController.isInDialog)
            rb.velocity = movement * moveSpeed;
    }

    void MovementInput ()
    {
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");

        movement = new Vector2(mx, my).normalized;
    }
}
