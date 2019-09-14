using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public Vector3 rotationOffset;

    private void Start()
    {
        transform.eulerAngles += rotationOffset;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }
}
