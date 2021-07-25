using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace CodeSampleOne
{
    public enum AnimalType
    {
        None = 0,
        Dog = 1,
        Cat = 2,
        Lizard = 3
    }
    [Serializable]
    public class Animal
    {
        public string id;
        public string name;
        public AnimalType type;

        public Animal(string i, string n, AnimalType t)
        {
            id = i;
            name = n;
            type = t;
        }

        public override string ToString()
        {
            return $"id: {id} name: {name} type: {type} | ";
        }
    }

    [Serializable]
    public class AnimalData
    {
        public Animal[] animalDataList;

        public override string ToString()
        {
            foreach (var i in animalDataList)
            {
                return $"{i.ToString()}";
            }
            return "";
        }
    }
}