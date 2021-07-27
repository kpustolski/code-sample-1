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

        public Dictionary<string, Sprite> animalSprites = new Dictionary<string, Sprite>();

        public void Initialize()
        {
            animalData = new AnimalData();
            LoadAnimalData();

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

        private void LoadAnimalData()
        {
            // Grabs the data from the JSON file
            TextAsset dataTextAsset = Resources.Load("AnimalData") as TextAsset;

            if (dataTextAsset == null)
            {
                Debug.LogError($"DataManager.cs Initialize() :: Unable to load the Animal Data File.");
                return;
            }

            Debug.Log($"Raw file text:{dataTextAsset.text}");

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

                if (IsAnimalValid(a))
                {
                    a.LoadSpriteImage();
                    tempList.Add(a);
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

        private bool DoesAnimalIdAlreadyExist(string id)
        {
            int copies = 0;
            for (int j = 0; j < animalData.animalDataList.Length; j++)
            {
                if (animalData.animalDataList[j].id.Equals(id))
                {
                    copies++;
                }
            }
            return copies > 1;
        }

        //Helper to do validation checks.
        private bool IsAnimalValid(Animal a)
        {
            if (string.IsNullOrEmpty(a.id))
            {
                Debug.LogError($"DataManager.cs IsAnimalValid.cs :: Animal with name: {a.name} has a missing or null unique id.");
                return false;
            }

            if (DoesAnimalIdAlreadyExist(a.id))
            {
                Debug.LogError($"DataManager.cs IsAnimalValid.cs :: Animal object of id {a.id} already exists. Make sure each object id is unique.");
                return false;
            }

            return true;
        }

        // public Animal GetAnimalById(string id)
        // {
        //     foreach (Animal a in animalData.animalDataList)
        //     {
        //         if (a.id.Equals(id))
        //         {
        //             return a;
        //         }
        //     }
        //     return null;
        // }
    }
}
