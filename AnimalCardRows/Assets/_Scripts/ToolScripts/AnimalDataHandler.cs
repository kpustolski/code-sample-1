using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CodeSampleOne
{
    [CreateAssetMenu(fileName = "Animal_Data_Editor", menuName = "Animal Data Editor")]

    public class AnimalDataHandler : ScriptableObject
    {
        public List<Animal> data = new List<Animal>();

        public override string ToString()
        {
            foreach (var a in data)
            {
                return $"{a.ToString()}";
            }
            return "";
        }

        public string CreateJsonStringFromData()
        {
            return JsonUtility.ToJson(this, true);
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