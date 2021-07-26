using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CodeSampleOne
{
    public class DataManager : MonoBehaviour
    {
        // Holds unsorted animal data
        private AnimalData animalData = default;
        // Holds sorted animal data
        public Dictionary<AnimalType, List<Animal>> sortedAnimalData = new Dictionary<AnimalType, List<Animal>>();

        public void Initialize()
        {
            // Grabs the data from the JSON file
            //TODO: Place json string in its own file and read in.
            string jsonString = "{\"animalDataList\":[{\"id\": \"animal1\", \"name\":\"bleep\", \"type\":1}, {\"id\": \"animal2\", \"name\":\"bloop\", \"type\":2}]}";
            animalData = new AnimalData();
            JsonUtility.FromJsonOverwrite(jsonString, animalData);

            // Loop through each entry in the AnimalType enum and sort
            foreach (AnimalType aniType in Enum.GetValues(typeof(AnimalType)))
            {
                if (aniType == AnimalType.None)
                {
                    continue;
                }

                SortAnimalListByType(aniType);
            }
        }

        private void SortAnimalListByType(AnimalType type)
        {
            List<Animal> tempList = new List<Animal>();
            foreach (Animal a in animalData.animalDataList)
            {
                if (IsAnimalValid(a))
                {
                    if (a.type == type)
                    {
                        tempList.Add(a);
                    }
                }
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

        private bool DoesAnimalExistById(string id)
        {
            for (int j = 0; j < animalData.animalDataList.Length; j++)
            {
                if (animalData.animalDataList[j].id.Equals(id))
                {
                    return true;
                }
            }
            return false;
        }

        //Helper to do validation checks.
        private bool IsAnimalValid(Animal a)
        {
            if (string.IsNullOrEmpty(a.id))
            {
                Debug.LogError($"DataManager.cs IsAnimalValid.cs :: Animal with name: {a.name} has a missing or null unique id.");
                return false;
            }

            if (DoesAnimalExistById(a.id))
            {
                Debug.LogError($"DataManager.cs IsAnimalValid.cs :: Animal object of id {a.id} already exists. Make sure each object id is unique.");
                return false;
            }

            return true;
        }
    }
}
