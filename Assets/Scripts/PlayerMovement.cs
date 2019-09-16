using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public bool isFlagPicked = false;
    public FixedJoystick joystick;
    float moveX, moveZ;
    // Update is called once per frame

    private void Start()
    {
        joystick = FindObjectOfType<FixedJoystick>();
    }
    void Update()
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
        GetComponent<Rigidbody>().velocity = movement * moveSpeed * Time.deltaTime;
    }
}
