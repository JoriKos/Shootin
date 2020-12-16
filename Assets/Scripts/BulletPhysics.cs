using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysics : MonoBehaviour
{
    private Shoot shoot;
    private Rigidbody rb;
    private Camera camera;
    private Ray rayOrigin;
    private RaycastHit hitInfo;
    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletHolePrefab;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera = FindObjectOfType<Camera>();
        shoot = camera.GetComponent<Shoot>();
        transform.position = camera.transform.position;
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(-speed, 0 + (Physics.gravity.y * 0.1f), 0.01f * shoot.GetWindSpeed()), ForceMode.Force); //Object is given force, affected by gravity and windspeed.
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TargetWall")
        {
            //If a target is hit, a raycast is used to determine the bullethole position, object is then destroyed
            if (Physics.Raycast(new Vector3(rb.transform.position.x, rb.transform.position.y, rb.transform.position.z), rb.transform.up, out hitInfo))
            {
                Instantiate(bulletHolePrefab, new Vector3(hitInfo.point.x + 0.19f, hitInfo.point.y, hitInfo.point.z), Quaternion.LookRotation(hitInfo.normal));
                Destroy(this.gameObject);
            }
        }
    }
}