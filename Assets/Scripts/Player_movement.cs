using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    private bool jumpQueued = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        bool jumpPressed = Input.GetButtonDown("Jump") || Input.GetButtonDown("Jump2");
        if (jumpPressed)
        {

            if (!jumpQueued)
            {
                jumpQueued = true;
            }
        }
        

    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jumpQueued);
        jumpQueued = false;
    }
}
