using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NPC
{
    namespace Enemy
    {
        public class Zombie : MonoBehaviour
        {
            public ZombieData zombie;
            public State state;

            private void Awake()
            {
                ZombieDB.Register();
                zombie.color = ZombieDB.colors[Random.Range(0, 3)];
                zombie.taste = ZombieDB.taste[Random.Range(0, 5)];
            }

            private void Start()
            {
                StartCoroutine("AzarvarMove");
            }

            private void Update()
            {
                Move();
            }

            public void Move()
            {
                switch (state)
                {
                    case State.iddle:
                        break;
                    case State.moving:
                        transform.position += transform.forward/15;
                        break;
                    case State.rotating:
                        float roter;
                        if (zombie.dir) { roter = transform.eulerAngles.y + 1; }
                        else { roter = transform.eulerAngles.y - 1; }
                        transform.eulerAngles = new Vector3(0, roter, 0);
                        break;
                }
            }//MOVIMIENTOS DEL ZOMBIE

            public enum State { iddle, moving, rotating };//ENUM DE ESTADOS

            IEnumerator AzarvarMove()
            {
                for (;;)
                {
                    zombie.dir = !zombie.dir;
                    state = (State)Random.Range(0, 3);
                    transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
                    yield return new WaitForSeconds(2);
                }
                
            }//CORRUTINA 
        }

        public struct ZombieData
        {
            public string taste;
            public Color color;
            public int state;
            public bool dir;
        } //ESTRUCTURA 

        public class ZombieDB : MonoBehaviour
        {
            public static string[] taste;
            public static Color[] colors;

            public static void Register()
            {
                colors = new Color[3] //registro de colores
                {
                    Color.cyan,
                    Color.magenta,
                    Color.green
                };

                taste = new string[5]
                {
                    "páncreas",
                    "cerebro",
                    "hígados",
                    "tumores, o pulmones asmáticos o riñones con cálculos",
                    "aparatos reproductores"
                };
            }
        } //BASE DE DATOS (COLORES, GUSTOS)

        
    }
}


//public static GameObject Create(GameObject reference)
//{
//    GameObject zombie = GameObject.Instantiate(reference) as GameObject;
//    zombie.transform.position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
//    zombie.AddComponent<Zombie>();
//    zombie.GetComponent<Zombie>().zombie.color = ZombieDB.colors[0];
//    zombie.GetComponent<Zombie>().zombie.taste = ZombieDB.taste[Random.Range(0, 5)];
//    zombie.GetComponent<MeshRenderer>().material.color = zombie.GetComponent<Zombie>().zombie.color;
//    return zombie;
//}//GENERADOR DE ZOMBIES