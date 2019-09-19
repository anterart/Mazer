using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : Player
{
    FixedJoystick joystick;
    float moveX, moveZ;
    public GameObject bulletPrefab;
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

    protected override void Shoot()
    {
        base.Shoot();
        if (Input.touchCount > 0)
        {

            if (Input.GetTouch(0).phase == TouchPhase.Began)
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
                    Vector3 dir = (touchPos - (new Vector3(transform.position.x, transform.position.y, transform.position.z))).normalized;
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
                    bullet.GetComponent<Rigidbody>().velocity = dir * bulletSpeed;
                    bullet.GetComponent<BulletBehavior>().owner = "Human";
                    System.Threading.Thread.Sleep(250);
                }
            }
        }
    }
}
