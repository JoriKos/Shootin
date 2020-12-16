using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Ray rayOrigin;
    private Camera camera;
    private Vector3 endGizmo;
    private Vector3 startGizmo;
    private RaycastHit hitInfo;
    [SerializeField] private float gizmoLength;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletHolePrefab;


    private void Start()
    {
        camera = FindObjectOfType<Camera>();
        startGizmo = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab);
            //Create hitscan bullet hole
            if (Physics.Raycast(new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z - 7), camera.transform.forward, out hitInfo)) 
            {
                Instantiate(bulletHolePrefab, new Vector3(hitInfo.point.x + 0.19f, hitInfo.point.y, hitInfo.point.z), Quaternion.LookRotation(hitInfo.normal));
            }
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < 20; i++) //Create hitscan aim gizmo
        {
            endGizmo = new Vector3(startGizmo.x - gizmoLength, startGizmo.y, startGizmo.z);
            Gizmos.DrawLine(startGizmo, endGizmo);
            startGizmo = transform.position;
        }
    }
}
