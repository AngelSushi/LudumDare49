using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;

    Vector2 movement;

    public Animator animator;

    public bool isInEnigma;
    public DialogController dialogController;
    public UserInventory inventory;

    private AudioSource Audio_Walk;

    [SerializeField] private AudioClip audioWalk = null;

    private void Awake()
    {
        Audio_Walk = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        float charaterVelocity = Mathf.Abs(rb.velocity.x);
       
        animator.SetBool("moove",movement != Vector2.zero);
        animator.SetFloat("horizontal",movement.x);
        animator.SetFloat("vertical",movement.y); 

        float horizontal = animator.GetFloat("horizontal");
        float vertical = animator.GetFloat("vertical");
         Audio_Walk.PlayOneShot(audioWalk);
        if(horizontal > 0) {
            for(int i = 0;i<4;i++) 
                transform.GetChild(i).gameObject.SetActive(false);
            
            transform.GetChild(0).gameObject.SetActive(true);
           
        }
        else if(horizontal < 0) {
            for(int i = 0;i<4;i++) 
                transform.GetChild(i).gameObject.SetActive(false);
            
            transform.GetChild(2).gameObject.SetActive(true);
        }

        if(vertical > 0) {
            for(int i = 0;i<4;i++) 
                transform.GetChild(i).gameObject.SetActive(false);
            
            transform.GetChild(3).gameObject.SetActive(true);
        }
        else if(vertical < 0) {
            for(int i = 0;i<4;i++) 
                transform.GetChild(i).gameObject.SetActive(false);
            
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if(!isInEnigma && !dialogController.isInDialog)
            rb.velocity = movement * moveSpeed;
        
    }



    public void OnMove(InputAction.CallbackContext e) {
        movement = e.ReadValue<Vector2>().normalized;
    }
}
