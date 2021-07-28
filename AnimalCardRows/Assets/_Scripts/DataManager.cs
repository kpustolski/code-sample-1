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

            // Check that the data is valid before continuing
            if (!IsAllDataValid())
            {
                return;
            }

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
                Debug.LogError($"DataManager.cs Initialize() :: Unable to load the Animal Data File.");
                return;
            }

            // Deserialize the JSON from AnimalData.JSON and store it in animalData
            JsonUtility.FromJsonOverwrite(dataTextAsset.text, animalData);
        }

        private void SortAnimalListByType(AnimalType type)
        {
            List<Animal> tempList = new List<Animal>();
            foreach (Animal a in animalData.animalDataList)
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

        /*
            The validation functions below could be made into a seperate debug tool for validating the data
            before we use it in the project.
        */
        private bool IsAllDataValid()
        {
            int errors = 0;
            foreach (Animal a in animalData.animalDataList)
            {
                if (!IsAnimalValid(a))
                {
                    errors++;
                }
            }

            Debug.Log($"DataManager.cs IsAllDataValid() :: Number of errors found in the data: {errors}");
            return errors == 0;
        }

        //Helper to do more validation checks of the animal data.
        private bool IsAnimalValid(Animal a)
        {
            if (!Enum.IsDefined(typeof(AnimalType), a.type))
            {
                Debug.LogError($"DataManager.cs IsAnimalValid.cs :: Animal with id: {a.id} has an incorrect type assigned. Make sure it's within the parameters of the AnimalType enum.");
                return false;
            }

            if (string.IsNullOrEmpty(a.id))
            {
                Debug.LogError($"DataManager.cs IsAnimalValid.cs :: Animal with name: {a.name} has a missing or null unique id.");
                return false;
            }

            if (DoesAnimalIdAlreadyExist(a.id))
            {
                Debug.LogError($"DataManager.cs IsAnimalValid.cs :: Animal object of id {a.id} already exists. Check object with the name: {a.name}. Make sure the id is unique for each object.");
                return false;
            }

            return true;
        }


        // Helper to see if there are duplicate animal objects in the list based on its id.
        // The id for each animal should be unique.
        private bool DoesAnimalIdAlreadyExist(string id)
        {
            int copies = 0;
            for (int i = 0; i < animalData.animalDataList.Length; i++)
            {
                if (animalData.animalDataList[i].id.Equals(id))
                {
                    copies++;
                }
            }
            return copies > 1;
        }
    }
}
