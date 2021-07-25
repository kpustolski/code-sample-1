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

        private List<Animal> AnimalDataList = new List<Animal>();


        // Holds sorted animal data
        public Dictionary<AnimalType, List<Animal>> sortedAnimalRowData = new Dictionary<AnimalType, List<Animal>>();

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
            AnimalData ad = new AnimalData();
            JsonUtility.FromJsonOverwrite(jsonString, ad);

            Debug.Log($"{ad.ToString()}");

            // TODO: Better way to consolodate array into List?
            foreach (var a in ad.animalDataList)
            {
                AddToAnimalList(a);
            }

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

        // Creates animal objects to debug with.
        public void DebugAnimals()
        {
            //Debug Objects
            Animal a1 = new Animal("animal1", "Foo", AnimalType.Dog);
            Animal a2 = new Animal("animal2", "Korra", AnimalType.Cat);
            Animal a3 = new Animal("animal3", "Aang", AnimalType.Lizard);
            Animal a4 = new Animal("animal4", "Bleep", AnimalType.Lizard);

            AddToAnimalList(a1);
            AddToAnimalList(a2);
            AddToAnimalList(a3);
            AddToAnimalList(a4);
        }

        //Helper to do validation checks and add data to the list.
        private void AddToAnimalList(Animal a)
        {
            ValidateList(a);
            AnimalDataList.Add(a);
        }

        private void ValidateList(Animal a)
        {
            if (string.IsNullOrEmpty(a.id))
            {
                Debug.LogError($"AppManager.cs AddToList.cs :: Animal with name: {a.name} has a missing or null unique id.");
                return;
            }

            if (DoesAnimalExistInListById(a.id))
            {
                Debug.LogError($"AppManager.cs AddToList.cs :: Animal object of id {a.id} already exists. Make sure each object id is unique.");
                return;
            }
        }

        private void SortAnimalListByType(AnimalType type)
        {
            List<Animal> tempList = new List<Animal>();
            foreach (Animal a in AnimalDataList)
            {
                if (a.type == type)
                {
                    tempList.Add(a);
                }
            }

            Debug.Log($"type: {type} tempList.Count: {tempList.Count}");
            if (tempList.Count != 0)
            {
                sortedAnimalRowData.Add(type, tempList);
            }
            else
            {
                Debug.Log($"No animal of type {type} found. Did not add new object to sortedAnimalRowData.");
            }
        }

        private bool DoesAnimalExistInListById(string id)
        {
            for (int j = 0; j < AnimalDataList.Count; j++)
            {
                if (AnimalDataList[j].id.Equals(id))
                {
                    return true;
                }
            }
            return false;
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}