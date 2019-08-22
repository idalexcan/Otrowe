using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Enemy;
using NPC.Ally;
using UnityEngine.UI;

public class General : MonoBehaviour
{
    public GameObject reference;//prefab de cubo para todos los personajes
    public Color herocol;//color para el héroe
    public Text Allys;
    public  Text Enemys;

    Characters chr;//instancia de caráteres

    void Start()
    {
        chr = new Characters(reference, herocol);
        Allys.text = "Villagers: "+Characters.villagers.Length;
        Enemys.text = "Zombies: "+Characters.zombies.Length;
        
    }
}

public class Characters
{
    
    public static GameObject[] zombies, villagers;//arreglos de NPC
    public static GameObject TheHero;//héroe
    //variables para cantidad de NPC
    readonly int minim;
    const int maxim = 25;
    int cantNPC;
    int cantAlly;
    int cantEnemy;

    public Characters(GameObject reference, Color herocolor)
    {
        //GENERANDO HEROE
        TheHero = GameObject.Instantiate(reference) as GameObject;
        TheHero.AddComponent<Hero>();
        TheHero.GetComponent<MeshRenderer>().material.color = herocolor;
        //ASIGNANDO CANTIDADES PARA NPC
        minim = Random.Range(5,15);
        cantNPC = Random.Range(minim, maxim+1);
        cantAlly = Random.Range(1, cantNPC);
        cantEnemy = cantNPC - cantAlly;
        //GENERANDO ZOMBIES
        zombies = new GameObject[cantEnemy];
        for (int i = 0; i < zombies.Length; i++)
        {
            zombies[i] = GameObject.Instantiate(reference) as GameObject;
            zombies[i].transform.position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            zombies[i].AddComponent<Zombie>();
            zombies[i].GetComponent<MeshRenderer>().material.color = zombies[i].GetComponent<Zombie>().zombie.color;
        }
        //GENERANDO ALDEANOS
        villagers = new GameObject[cantAlly];
        for (int i = 0; i < villagers.Length; i++)
        {
            villagers[i] = GameObject.Instantiate(reference) as GameObject;
            villagers[i].transform.position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            villagers[i].AddComponent<Villagers>();
            villagers[i].GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }
}




//public class General : MonoBehaviour
//{
//    public GameObject reference;//prefab de cubo para todos los personajes
//    GameObject[] zombies, villagers;
//    public static GameObject TheHero;
//    public Color herocol;

//    void Start()
//    {
//        TheHero = GameObject.Instantiate(reference) as GameObject;
//        TheHero.AddComponent<Hero>();
//        TheHero.GetComponent<MeshRenderer>().material.color = herocol;

//        zombies = new GameObject[5];
//        for (int i = 0; i < zombies.Length; i++)
//        {
//            zombies[i] = GameObject.Instantiate(reference) as GameObject;
//            zombies[i].transform.position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
//            zombies[i].AddComponent<Zombie>();
//            zombies[i].GetComponent<MeshRenderer>().material.color = zombies[i].GetComponent<Zombie>().zombie.color;
//        }

//        villagers = new GameObject[5];
//        for (int i = 0; i < villagers.Length; i++)
//        {
//            villagers[i] = GameObject.Instantiate(reference) as GameObject;
//            villagers[i].transform.position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
//            villagers[i].AddComponent<Villagers>();
//            villagers[i].GetComponent<MeshRenderer>().material.color = Color.yellow;
//        }
//    }

//    void Update()
//    {

//    }
//}





