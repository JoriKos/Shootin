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
    private RaycastHit hitInfo;
    private Vector3 windSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float windChangeInterval;
    [SerializeField] private GameObject bulletHolePrefab;


    private void Start()
    {
        windText = FindObjectOfType<Text>();
        camera = FindObjectOfType<Camera>();
        timer = 0;
        windText.text = "Windspeed: X: Y: Z: ";
    }
    
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > windChangeInterval)
        {
            timer = 0;
            windSpeed = new Vector3(
                Mathf.Round(Random.Range(-1.0f, 1.0f) * 100),
                0,
                Mathf.Round(Random.Range(-1.0f, 1.0f) * 100));
        }
        windText.text = "Windspeed: X: " + windSpeed.x.ToString() + " Y: " + windSpeed.y.ToString() + " Z: " + windSpeed.z.ToString();

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
    
    public Vector3 GetVectorWind() //BulletPhysics.cs is not always instantiated, global wind needed rather than bullet-specific wind
    {
        return windSpeed;
    }
}
