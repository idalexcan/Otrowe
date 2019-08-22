using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC
{
    namespace Ally
    {
        public class Villagers : MonoBehaviour
        {
            public VillData villager;

            private void Awake()
            {
                VillagerDB.Register();

                villager.name = VillagerDB.names[Random.Range(0, 20)];
                villager.age = Random.Range(15, 101);
            }
            
        }

        public struct VillData
        {
            public string name;
            public int age;
        }

        public class VillagerDB
        {
            public static string[] names;
            
            public static void Register()
            {
                names = new string[]
                {
                    "Sanderson Saldarriaga",
                    "Johan Strauss ll tercero",
                    "Johan SADdler F",
                    "Pocoyó",
                    "Muchoyó",
                    "Barbie Enfermera Prepago",
                    "Darius Gomus",
                    "Luisalbertus Posadus",
                    "The Charritus Negrus",
                    "Rodolfus Aicardus",
                    "Pepito Perez Company ft Zelig's Company (F por Zelig)",
                    "Foo Miniquica",
                    "Diomedes Noches",
                    "Una Mosca Adolorida",
                    "Una Abeja Pitilluda",
                    "Bolivian Shark",
                    "Colomboninbolus",
                    "Comunímbulo",
                    "Comulinombus",
                    "Cumulonimbus"
                };
            }
        }
    }
}

