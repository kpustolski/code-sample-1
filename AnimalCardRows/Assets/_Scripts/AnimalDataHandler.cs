using System.Collections.Generic;
using UnityEngine;
using System;

namespace CodeSampleOne
{
    // This class helps with the data on the AnimalDataEditor tool.
    [CreateAssetMenu(fileName = "Animal_Data_Editor", menuName = "Animal Data Editor")]
    public class AnimalDataHandler : ScriptableObject
    {
        public List<Animal> data = new List<Animal>();

        public string CreateJsonStringFromData(bool makeJSONPretty)
        {
            return JsonUtility.ToJson(this, makeJSONPretty);
        }

        public int ValidateData()
        {
            int errors = 0;
            foreach (Animal a in data)
            {
                if (!IsAnimalValid(a))
                {
                    errors++;
                }
            }

            return errors;
        }

        //Helper to do more validation checks of the animal data.
        private bool IsAnimalValid(Animal a)
        {
            if (string.IsNullOrEmpty(a.id))
            {
                Debug.LogError($"AnimalDataHandler.cs IsAnimalValid() :: Animal with name: {a.name} has a missing or null unique id.");
                return false;
            }

            if (DoesAnimalIdAlreadyExist(a.id))
            {
                Debug.LogError($"AnimalDataHandler.cs IsAnimalValid() :: Animal object of id {a.id} already exists. Check object with the name: {a.name}. Make sure the id is unique for each object.");
                return false;
            }

            return true;
        }


        // Helper to see if there are duplicate animal objects in the list based on its id.
        // The id for each animal should be unique.
        private bool DoesAnimalIdAlreadyExist(string id)
        {
            int copies = 0;
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].id.Equals(id))
                {
                    copies++;
                }
            }
            return copies > 1;
        }
    }
}