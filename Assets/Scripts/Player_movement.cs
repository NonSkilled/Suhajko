using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    private bool jumpQueued = false;
    bool isSprinting = false;
    public float sprintSpeed = 80f;

    void Update()
    {
        if (isSprinting && controller.IsGrounded)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * sprintSpeed;
        }
        else
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }
        animator.SetFloat ("Speed", Mathf.Abs(horizontalMove));
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && controller.IsGrounded)
        {

            if (!jumpQueued)
            {
                jumpQueued = true;
            }
        }
        bool sprintPressed = Input.GetKey(KeyCode.LeftShift);
        if (sprintPressed)
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
        

    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jumpQueued, isSprinting);
        jumpQueued = false;
    }
}
