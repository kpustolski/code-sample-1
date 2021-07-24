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
        public string Id;
        public string Name;
        public AnimalType Type;
    }
}