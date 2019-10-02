using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HumanPlayer : Player
{
    public Vector3 mainCameraOffset;
    public Vector3 mainCameraRotationOffset;
    public FixedJoystick joystick;
    float moveX, moveZ;
    Animator anim;
    private Vector3 lastDirection;
    private RectTransform pointerRectTransform;
    public Sprite redArrow;
    public Sprite yellowArrow;
    public Sprite blueArrow;
    public float edgeBuffer;
    public bool hasFired;

    protected override void Awake()
    {
        base.Awake();
        pointerRectTransform = GameObject.Find("Canvas").transform.Find("PointerHolder").Find("Pointer").GetComponent<RectTransform>();
        moveSpeed = 300f;
        isHuman = true;
        hasFired = false;
    }
    protected override void Start()
    {
        base.Start();
        Camera.main.transform.eulerAngles = mainCameraRotationOffset;
        joystick = FindObjectOfType<FixedJoystick>();
        prefab = gm.GetComponent<GameManager>().humanPlayer;
        anim = GetComponentInChildren<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        MoveCamera();
        UpdatePointer();
    }

    protected override void Move()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
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
        if (anim.GetBool("walking"))
        {
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * 180 / Mathf.PI, 0); // Face the walking direction
        }
        rb.velocity = movement * moveSpeed * Time.deltaTime;
    }

    protected override void Shoot()
    {
        foreach (Touch touch in Input.touches)
        {
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId) && touch.phase == TouchPhase.Began)
            {
                // create ray from the camera and passing through the touch position:
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                // create a logical plane at this object's position
                // and perpendicular to world Y:
                Plane plane = new Plane(Vector3.up, transform.position);
                float distance = 0; // this will return the distance from the camera
                if (plane.Raycast(ray, out distance))
                { // if plane hit...
                    anim.SetBool("shoot", true);
                    hasFired = true;
                    Invoke("setShootFalse", 0.7f);
                    Vector3 touchPos = ray.GetPoint(distance); // get the point
                                                                // pos has the position in the plane you've touched  
                    base.ShootHelper(touchPos);
                }
            }
        }    
    }

    private void setShootFalse()
    {
        anim.SetBool("shoot", false);
    }

    private void MoveCamera()
    {
        Camera.main.transform.position = transform.position + mainCameraOffset;
    }

    private void UpdatePointer()
    {
        if (GameObject.ReferenceEquals(gm.flagOwner, gameObject))
        {
            pointerRectTransform.GetComponent<Image>().sprite = yellowArrow;
        }
        else if (gm.picked)
        {
            pointerRectTransform.GetComponent<Image>().sprite = blueArrow;
        }
        else
        {
            pointerRectTransform.GetComponent<Image>().sprite = redArrow;
        }
        Vector3 toPosition = GetTargetPosition();
        Vector3 newPos = Camera.main.WorldToViewportPoint(toPosition);
        bool outOfScreen = false;
        if (newPos.x > 1 || newPos.y > 1 || newPos.x < 0 || newPos.y < 0)
        {
            outOfScreen = true;
        }
        if (newPos.z < 0)
        {
            newPos.x = 1f - newPos.x;
            newPos.y = 1f - newPos.y;
            newPos.z = 0f;
            newPos = Vector3Maximize(newPos);
        }
        newPos = Camera.main.ViewportToScreenPoint(newPos);
        newPos.x = Mathf.Clamp(newPos.x, edgeBuffer, Screen.width - edgeBuffer);
        newPos.y = Mathf.Clamp(newPos.y, edgeBuffer, Screen.height - edgeBuffer);
        pointerRectTransform.position = newPos;
        if (outOfScreen)
        {
            pointerRectTransform.gameObject.SetActive(true);
            Vector3 targetPosLocal = Camera.main.transform.InverseTransformPoint(toPosition);
            float targetAngle = -Mathf.Atan2(targetPosLocal.x, targetPosLocal.y) * Mathf.Rad2Deg + 90;
            pointerRectTransform.eulerAngles = new Vector3(0, 0, targetAngle);
        }
        else
        {
            pointerRectTransform.gameObject.SetActive(false);
        }
        
    }

    private Vector3 Vector3Maximize(Vector3 vector)
    {
        Vector3 returnVector = vector;
        float max = 0;
        max = vector.x > max ? vector.x : max;
        max = vector.y > max ? vector.y : max;
        max = vector.z > max ? vector.z : max;
        if (max > 0)
        {
            returnVector /= max;
        }
        return returnVector;
    }


}
