using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeSampleOne
{
    public enum AnimalType
    {
        None = 0,
        Dog = 1,
        Cat = 2,
        Lizard = 3
    }

    public class Animal
    {
        public string id;
        public string name;
        public AnimalType type;

        public Animal(string id, string name, AnimalType type)
        {
            id = this.id;
            name = this.name;
            type = this.type;
        }
    }
}