using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private float timer;
    private Camera camera;
    private Ray rayOrigin;
    private Text windText;
    private float windSpeed;
    private Vector3 endGizmo;
    private Vector3 startGizmo;
    private RaycastHit hitInfo;
    [SerializeField] private float gizmoLength;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float windChangeInterval;
    [SerializeField] private GameObject bulletHolePrefab;


    private void Start()
    {
        windText = FindObjectOfType<Text>();
        camera = FindObjectOfType<Camera>();
        startGizmo = transform.position;
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > windChangeInterval)
        {
            timer = 0;
            windSpeed = Mathf.Round(Random.Range(-1.0f, 1.0f) * 100);
        }
        windText.text = "Windspeed: " + windSpeed.ToString();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab);
            //Create hitscan bullet hole
            if (Physics.Raycast(new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z), camera.transform.forward, out hitInfo)) 
            {
                Instantiate(bulletHolePrefab, new Vector3(hitInfo.point.x + 0.19f, hitInfo.point.y, hitInfo.point.z), Quaternion.LookRotation(hitInfo.normal));
            }
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < 500; i++) //Create hitscan aim gizmo
        {
            endGizmo = new Vector3(startGizmo.x - gizmoLength, startGizmo.y, startGizmo.z);
            Gizmos.DrawLine(startGizmo, endGizmo);
            startGizmo = transform.position;
        }
    }
    
    public float GetWindSpeed()
    {
        return windSpeed;
    }
}
