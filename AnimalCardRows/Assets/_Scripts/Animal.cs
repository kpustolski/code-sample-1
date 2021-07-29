using UnityEngine;
using System;
using System.Collections.Generic;

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
        // File name corresponds to sprites in the Resources/AnimalImages folder.
        // There's probably a better way to assign the sprite other than a string for the
        // JSON, but for now I'll keep it a string.
        public string spriteFileName;
        [TextArea(3, 5)]
        public string description;
        private Sprite aniSprite;
        public Sprite AniSprite { get { return aniSprite; } private set { aniSprite = value; } }

        public Animal(string i, string n, AnimalType t, string sp, string d)
        {
            id = i;
            name = n;
            type = t;
            spriteFileName = sp;
            description = d;
        }

        public override string ToString()
        {
            return $"id: {id} name: {name} type: {type} spriteFileName: {spriteFileName} description {description}";
        }

        public void Setup()
        {
            if (string.IsNullOrEmpty(spriteFileName))
            {
                Debug.Log($"Animal.cs Setup() :: No image file name for animal with id: {id} found. Card will be blank.");
                return;
            }

            // Load and assign the proper sprite 
            string filePath = $"AnimalImages/{spriteFileName}";
            AniSprite = Resources.Load<Sprite>(filePath);

            if (AniSprite == null)
            {
                Debug.LogError($"Animal.cs Setup() :: Sprite with file path {filePath} not found. Check your spelling in the JSON or that the image is in the correct folder.");
            }
        }
    }

    // This class helps store the deserialized JSON data in DataManager.cs
    [Serializable]
    public class AnimalData
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
    }
}