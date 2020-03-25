using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public CharacterController2D controler;

    private float horizontalMove = 0;

    public float runSpeed = 40;

    private bool jump = false;
    private bool crouch = false;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("jumping", jump);
        }

        if (Input.GetAxisRaw("Crouch") == -1)
        {
            crouch = true;
        }
        else 
        {
            crouch = false;
        }
    }
    public void OnLand()
    {
        animator.SetBool("jumping", false);
    }
    private void FixedUpdate()
    {
        controler.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
