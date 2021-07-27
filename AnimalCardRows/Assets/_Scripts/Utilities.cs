using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeSampleOne
{
    public static class Utilities
    {

        #region Debug Functions
        // Creates animal objects to debug with.
        public static List<Animal> DebugAnimals()
        {
            List<Animal> tempList = new List<Animal>();
            Animal a1 = new Animal("animal1", "Katara", AnimalType.Dog, "");
            Animal a2 = new Animal("animal2", "Korra", AnimalType.Cat, "");
            Animal a3 = new Animal("animal3", "Aang", AnimalType.Lizard, "");
            Animal a4 = new Animal("animal4", "Asami", AnimalType.Lizard, "");

            tempList.Add(a1);
            tempList.Add(a2);
            tempList.Add(a3);
            tempList.Add(a4);

            return tempList;

        }
        #endregion

    }
}