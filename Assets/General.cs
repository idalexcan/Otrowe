using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;


public class General : MonoBehaviour
{
    public GameObject reference;
    GameObject[] zombies;
    GameObject TheHero;
    void Start()
    {
        TheHero = GameObject.Instantiate(reference) as GameObject;
        TheHero.AddComponent<Hero>();


        zombies = new GameObject[15];
        for (int i = 0; i < zombies.Length; i++)
        {
            zombies[i] = GameObject.Instantiate(reference) as GameObject;
            zombies[i].transform.position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            zombies[i].AddComponent<Zombie>();
            zombies[i].GetComponent<MeshRenderer>().material.color = zombies[i].GetComponent<Zombie>().zombie.color;
        }
    }

    void Update()
    {

    }
}





