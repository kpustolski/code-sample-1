using System.Collections.Generic;
using UnityEngine;
using System;

namespace CodeSampleOne
{
    public class DataManager
    {
        // Holds unsorted animal data
        private AnimalData animalData = default;
        // Holds sorted animal data
        public Dictionary<AnimalType, List<Animal>> sortedAnimalData = new Dictionary<AnimalType, List<Animal>>();

        public void Initialize()
        {
            animalData = new AnimalData();
            LoadAnimalData();

            // Loop through each entry in the AnimalType enum and sort the animal objects
            foreach (AnimalType aniType in Enum.GetValues(typeof(AnimalType)))
            {
                if (aniType == AnimalType.None)
                {
                    continue;
                }

                SortAnimalListByType(aniType);
            }
        }
        /*
            Ideally the data would be pulled from a server of some sort via
            in more complex systems. In this example, I'm keeping the
            data local in the Resources folder. 
        */
        private void LoadAnimalData()
        {
            // Grab the data file
            TextAsset dataTextAsset = Resources.Load("AnimalData") as TextAsset;

            if (dataTextAsset == null)
            {
                Debug.LogError($"DataManager.cs LoadAnimalData() :: Unable to load the Animal Data File.");
                return;
            }

            // Deserialize the JSON from AnimalData.JSON and store it in animalData
            JsonUtility.FromJsonOverwrite(dataTextAsset.text, animalData);
        }

        private void SortAnimalListByType(AnimalType type)
        {
            List<Animal> tempList = new List<Animal>();
            foreach (Animal a in animalData.data)
            {
                if (a.type != type)
                {
                    continue;
                }

                // Setup will handle assigning the proper sprite to the animal object.
                a.Setup();
                tempList.Add(a);
            }

            if (tempList.Count != 0)
            {
                sortedAnimalData.Add(type, tempList);
            }
            else
            {
                Debug.Log($"DataManager.cs SortAnimalListByType() :: No animal of type {type} found. Did not add new object to sortedAnimalData.");
            }
        }
    }
}
