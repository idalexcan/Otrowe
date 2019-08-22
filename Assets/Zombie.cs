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
                ZombieDB.Register(); //para generar los gustos y colores

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

            public void Move() //MOVIMIENTOS DEL ZOMBIE 
            {
                switch (state)// switch de estados del zombie
                {
                    case State.iddle://quieto
                        break;
                    case State.moving://caminando en dirección aleatoria
                        transform.position += transform.forward/15;
                        break;
                    case State.rotating://rotando en dirección aleatoria 
                        float roter;
                        if (zombie.dir)
                        { roter = transform.eulerAngles.y + 1; }
                        else
                        { roter = transform.eulerAngles.y - 1; }
                        transform.eulerAngles = new Vector3(0, roter, 0);
                        //zombie.dir es un boleano que indica la dirección
                        //cambiando su valor cada 5s en la corrutina
                        break;
                }
            } 

            public enum State { iddle, moving, rotating };//ENUM DE ESTADOS

            IEnumerator AzarvarMove() //CORRUTINA 
            {
                for (;;)//3 variables del zombie cambian cada 5s en la corrutina
                {
                    zombie.dir = !zombie.dir;//dirección para el estado de rotación
                    state = (State)Random.Range(0, 3);//estado 
                    transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);//dirección en eje y para movimiento
                    yield return new WaitForSeconds(5);
                }
                
            } 
        }

        public struct ZombieData //ESTRUCTURA DE UN ZOMBIE
        {
            public string taste;
            public Color color;
            public int state;
            public bool dir;
        }

        public class ZombieDB //BASE DE DATOS (COLORES, GUSTOS)
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

                taste = new string[5] //registro de gustos

                {
                    "páncreas",
                    "cerebro",
                    "hígados",
                    "tumores, o pulmones asmáticos o riñones con cálculos",
                    "aparatos reproductores"
                };
            }
        } //CLASE DE DATOS DEL ZOMBIE


    }
}
