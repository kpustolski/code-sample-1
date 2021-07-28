using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeSampleOne
{
    [CreateAssetMenu(fileName = "Animal_Data_Editor", menuName = "Animal Data Editor")]

    public class AnimalDataHandler : ScriptableObject
    {
        public List<Animal> data = new List<Animal>();

        public string CreateJsonStringFromData()
        {
            return JsonUtility.ToJson(this, true);
        }
    }
}