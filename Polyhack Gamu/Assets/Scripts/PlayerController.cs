using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    public GameObject projectile;
    public float moveSpeed;
    Camera viewCamera;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //movements
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        playerRigidBody.velocity = movement * moveSpeed;
        playerRigidBody.MovePosition(playerRigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);

        //aim direction
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Vector3 straightPoint = new Vector3(point.x, transform.position.y, point.z);
            transform.LookAt(straightPoint);
        }

        //transform.position = new Vector2(transform.position.x + (moveHorizontal * moveSpeed),
        //   transform.position.y + (moveVertical * moveSpeed));

    }
}
