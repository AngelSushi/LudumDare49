using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;

    Vector2 movement;

    //public Animator animator;

    public bool isInEnigma;
    public DialogController dialogController;
    public UserInventory inventory;

    // Update is called once per frame
    void Update()
    {
        float charaterVelocity = Mathf.Abs(rb.velocity.x);


        //animator.SetFloat("Speed", charaterVelocity);
    }

    private void FixedUpdate()
    {
        if(!isInEnigma && !dialogController.isInDialog)
            rb.velocity = movement * moveSpeed;
    }



    public void OnMove(InputAction.CallbackContext e) {
        Debug.Log("enter");
        movement = e.ReadValue<Vector2>().normalized;
    }
}
