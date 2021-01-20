using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windicator : MonoBehaviour
{
    private Quaternion rotation;
    private Shoot shoot;

    private void Awake()
    {
        shoot = FindObjectOfType<Camera>().GetComponent<Shoot>();
    }

    private void Update()
    {
        rotation = Quaternion.Euler(shoot.GetVectorWind());
        this.gameObject.transform.rotation = rotation;
    }
}
