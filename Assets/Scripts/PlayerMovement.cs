﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Camera camera;
    [SerializeField] private float speed;
    [SerializeField] private float MIN_X;
    [SerializeField] private float MAX_X;
    [SerializeField] private float MIN_Y;
    [SerializeField] private float MAX_Y;
    [SerializeField] private float MIN_Z;
    [SerializeField] private float MAX_Z;

    private void Awake()
    {
        camera = FindObjectOfType<Camera>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) //Scroll up
        {
            camera.fieldOfView += 10;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) //Scroll down
        {
            camera.fieldOfView -= 10;
        }
        if (camera.fieldOfView <= 10)
        {
            camera.fieldOfView = 10;
        }
        if (camera.fieldOfView >= 60)
        {
            camera.fieldOfView = 60;
        }
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, MIN_X, MAX_X),
            Mathf.Clamp(transform.position.y, MIN_Y, MAX_Y),
            Mathf.Clamp(transform.position.z, MIN_Z, MAX_Z));
    }
}
