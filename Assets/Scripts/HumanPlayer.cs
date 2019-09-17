using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : Player
{
    public float moveSpeed = 10f;
    FixedJoystick joystick;
    float moveX, moveZ;

    protected override void Start()
    {
        base.Start();
        joystick = FindObjectOfType<FixedJoystick>();
    }

    protected override void Move()
    {
        if (joystick.Horizontal >= .2f)
        {
            moveX = 1f;
        }
        else if (joystick.Horizontal <= -.2f)
        {
            moveX = -1f;
        }
        else
        {
            moveX = 0f;
        }
        if (joystick.Vertical >= .2f)
        {
            moveZ = 1f;
        }
        else if (joystick.Vertical <= -.2f)
        {
            moveZ = -1f;
        }
        else
        {
            moveZ = 0f;
        }

        // Movement
        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        rb.velocity = movement * moveSpeed * Time.deltaTime;
    }
}
