using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSim : MonoBehaviour
{
    public static float rotY;

    void Start()
    {

    }

    float x = 0;
    float y = 0;

    void Update()
    {
        transform.position = Hero.pos;
        x -= Input.GetAxis("Mouse Y");
        y += Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(x, y, 0);
        rotY = transform.eulerAngles.y;
    }
}
