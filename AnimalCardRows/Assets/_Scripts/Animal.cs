using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace CodeSampleOne
{
    public enum AnimalType
    {
        None = 0,
        Dog = 1,
        Cat = 2,
        Lizard = 3
    }
    [Serializable]
    public class Animal
    {
        public string id;
        public string name;
        public AnimalType type;
        public string spriteFileName;
        private Sprite aniSprite;
        public Sprite AniSprite { get { return aniSprite; } private set { aniSprite = value; } }

        public Animal(string i, string n, AnimalType t, string sp)
        {
            id = i;
            name = n;
            type = t;
            spriteFileName = sp;
        }

        public override string ToString()
        {
            return $"id: {id} name: {name} type: {type} spriteFileName: {spriteFileName}";
        }

        public void Setup()
        {
            if (string.IsNullOrEmpty(spriteFileName))
            {
                Debug.Log($"No image file name for animal with id: {id} found.");
                return;
            }

            string filePath = $"AnimalImages/{spriteFileName}";
            AniSprite = Resources.Load<Sprite>(filePath);
        }
    }

    [Serializable]
    public class AnimalData
    {
        public Animal[] animalDataList;

        public override string ToString()
        {
            foreach (var i in animalDataList)
            {
                return $"{i.ToString()}";
            }
            return "";
        }
    }
}