using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CodeSampleOne
{
    public class AppManager : MonoBehaviour
    {
        [Header("Views")]
        [Space(10)]
        [SerializeField]
        private HomeView homeView = default;

        [Header("Prefabs")]
        [Space(10)]
        [SerializeField]
        private AnimalRow animalRowPrefab = default;
        [SerializeField]
        private AnimalCard animalCardPrefab = default;
        public AnimalRow AnimalRowPrefab { get { return animalRowPrefab; } }
        public AnimalCard AnimalCardPrefab { get { return animalCardPrefab; } }
        private AnimalData animalData = default;
        // Holds sorted animal data
        public Dictionary<AnimalType, List<Animal>> sortedAnimalData = new Dictionary<AnimalType, List<Animal>>();

        //Global Static Variables
        public static AppManager Instance { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
            // https://forum.unity.com/threads/how-to-load-an-array-with-jsonutility.375735/
            // diegoadrada post
            // DebugAnimals();
            //TODO: Place json string in its own file and read in.
            //TODO: Create DataManager?
            string jsonString = "{\"animalDataList\":[{\"id\": \"animal1\", \"name\":\"bleep\", \"type\":1}, {\"id\": \"animal2\", \"name\":\"bloop\", \"type\":2}]}";
            animalData = new AnimalData();
            JsonUtility.FromJsonOverwrite(jsonString, animalData);

            // Loop through each entry in the AnimalType enum
            foreach (AnimalType aniType in Enum.GetValues(typeof(AnimalType)))
            {
                if (aniType == AnimalType.None)
                {
                    continue;
                }

                SortAnimalListByType(aniType);
            }

            //Setup the home view
            homeView.Setup();
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
                Debug.Log($"No animal of type {type} found. Did not add new object to sortedAnimalData.");
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
                Debug.LogError($"AppManager.cs IsAnimalValid.cs :: Animal with name: {a.name} has a missing or null unique id.");
                return false;
            }

            if (DoesAnimalExistById(a.id))
            {
                Debug.LogError($"AppManager.cs IsAnimalValid.cs :: Animal object of id {a.id} already exists. Make sure each object id is unique.");
                return false;
            }

            return true;
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}