using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : Player
{
    public Vector3 mainCameraOffset;
    public Vector3 mainCameraRotationOffset;
    FixedJoystick joystick;
    float moveX, moveZ;

    protected override void Awake()
    {
        base.Awake();
        moveSpeed = 300f;
    }
    protected override void Start()
    {
        base.Start();
        Camera.main.transform.eulerAngles = mainCameraRotationOffset;
        joystick = FindObjectOfType<FixedJoystick>();
        prefab = gm.GetComponent<GameManager>().humanPlayer;
    }

    protected override void Update()
    {
        base.Update();
        MoveCamera();
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

    protected override void Shoot()
    {
        base.Shoot();
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (joystick.Horizontal == 0f && joystick.Vertical == 0f)
                {
                    // create ray from the camera and passing through the touch position:
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    // create a logical plane at this object's position
                    // and perpendicular to world Y:
                    Plane plane = new Plane(Vector3.up, transform.position);
                    float distance = 0; // this will return the distance from the camera
                    if (plane.Raycast(ray, out distance))
                    { // if plane hit...
                        Vector3 touchPos = ray.GetPoint(distance); // get the point
                                                                   // pos has the position in the plane you've touched  
                        base.ShootHelper(touchPos);
                    }
                }
            }
        }
        else if (Input.touchCount == 2)
        {
            if (Input.GetTouch(1).phase == TouchPhase.Began)
            {
                // create ray from the camera and passing through the touch position:
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(1).position);
                // create a logical plane at this object's position
                // and perpendicular to world Y:
                Plane plane = new Plane(Vector3.up, transform.position);
                float distance = 0; // this will return the distance from the camera
                if (plane.Raycast(ray, out distance))
                { // if plane hit...
                    Vector3 touchPos = ray.GetPoint(distance); // get the point
                                                               // pos has the position in the plane you've touched  
                    base.ShootHelper(touchPos);
                }
            }
        }
    }

    private void MoveCamera()
    {
        Camera.main.transform.position = transform.position + mainCameraOffset;
    }
}
