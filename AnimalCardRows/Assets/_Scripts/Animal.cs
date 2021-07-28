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
        // File name corresponds to sprites in the Resources/AnimalImages folder.
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
                Debug.Log($"Animal.cs Setup() :: No image file name for animal with id: {id} found. Card will be blank.");
                return;
            }

            /*
                In a more complex system, the images could be downloaded from the server
                and cached locally on the players device for reuse. I'm keeping this example local,
                so I've placed the images in the Resources/AnimalImages folder.
            */

            // Load and assign the proper sprite 
            string filePath = $"AnimalImages/{spriteFileName}";
            AniSprite = Resources.Load<Sprite>(filePath);

            //TODO: Test this check
            if (AniSprite == null)
            {
                Debug.LogError($"Animal.cs Setup() :: Sprite with file path {filePath} not found. Check your spelling in the JSON or that the image is in the correct folder.");
            }
        }
    }
}