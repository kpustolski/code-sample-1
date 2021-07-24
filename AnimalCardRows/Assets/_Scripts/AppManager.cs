using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        public AnimalCard AnimalCard { get { return animalCardPrefab; } }
        public static List<Animal> AnimalList;

        //Global Variables
        public static AppManager Instance { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            Instance = this;

            //TODO: Create JSON file of animals
            DebugAnimals();

            //Setup the home view
            homeView.Setup();
        }

        // Creates animal objects to debug with.
        public void DebugAnimals()
        {
            //TODO: Create JSON file of animals
            AnimalList = new List<Animal>();
            //Debug Objects
            Animal a1 = new Animal(id: "animal1", name: "Foo", type: AnimalType.Dog);
            Animal a2 = new Animal(id: "animal2", name: "Korra", type: AnimalType.Cat);
            Animal a3 = new Animal(id: "animal3", name: "Aang", type: AnimalType.Lizard);

            AnimalList.Add(a1);
            AnimalList.Add(a2);
            AnimalList.Add(a3);

            // Check for unique Ids
            // Error checking
            for (int i = 0; i < AnimalList.Count; i++)
            {
                if (CheckForUniqueIds(AnimalList[i].id))
                {
                    Debug.LogError($"AppManager.cs DebugAnimals.cs :: Duplicate object found for id {AnimalList[i].id}. Make sure each object id is unique.");
                }
            }
        }

        public static bool CheckForUniqueIds(string id)
        {
            foreach (Animal ani in AnimalList)
            {
                if (ani.id.Equals(id))
                {
                    // There is a duplicate ID
                    return true;
                }
            }
            // All good
            return false;
        }
        public void Quit()
        {
            Application.Quit();
        }
    }
}