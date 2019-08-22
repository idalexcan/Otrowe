﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;
using System;

public class Hero : MonoBehaviour
{
    /// <summary>
    /// 1. var de posición estática para conectar la cámara
    /// 2. velocidad del heroe es readonly, y es un número random
    /// 3. canjump indica si el heroe se encuentra tocando un suelo
    /// </summary>
    public Vector3 pos;
    public readonly float speed;
    bool canJump = false;

    public Hero()
    {
        System.Random rn = new System.Random();
        speed = rn.Next(3, 7);
        print("CONSTRUCTOR" + speed);
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(0, FPSim.rotY, 0);
        if (Input.GetKey("w")) { transform.position += transform.forward * (speed / 20); }
        if (Input.GetKey("s")) { transform.position -= transform.forward * (speed / 20); }
        if (Input.GetKey("d")) { transform.position += transform.right * (speed / 20); }
        if (Input.GetKey("a")) { transform.position -= transform.right * (speed / 20); }
        pos = transform.position;

        if ((Input.GetKeyDown(KeyCode.Space)) && (canJump))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        canJump = true;
        if (col.gameObject.GetComponent<Zombie>())
        {
            Debug.Log("Waaaarrrr quiero comer " + col.gameObject.GetComponent<Zombie>().zombie.taste);
        }
        //else if (col.gameObject.GetComponent<Citizen>())
        //{
        //    Debug.Log("Holandas! soy " + col.gameObject.GetComponent<Citizen>().citizen.name
        //        + " y tengo " + col.gameObject.GetComponent<Citizen>().citizen.age + " años");
        //    col.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        //}
    }
}
