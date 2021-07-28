using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CodeSampleOne
{
    public class HomeView : MonoBehaviour
    {
        // Parent object to the instantiated rows.
        [SerializeField]
        private RectTransform rowParent = default;
        [SerializeField]
        private TextMeshProUGUI titleText = default;
        private List<AnimalRow> animalRowList = new List<AnimalRow>();
        private AppManager appMan = default;

        // This would be localized and more dynamic in a more robust system.
        // I'm keeping it a const string for simplicity.
        private const string viewTitle = "Party Animals";

        public void Setup()
        {
            appMan = AppManager.Instance;
            titleText.text = viewTitle;

            // Create the rows of animals based on the list in the DataManager
            foreach (var ani in appMan.DataManager.sortedAnimalData)
            {
                CreateAnimalRows(type: ani.Key, animalData: ani.Value);
            }
        }

        private void CreateAnimalRows(AnimalType type, List<Animal> animalData)
        {
            string rowTitle = GetRowTitleByAnimalType(type: type);
            AnimalRow row = Instantiate(appMan.AnimalRowPrefab, rowParent);
            row.Setup(title: rowTitle, aniData: animalData);
            animalRowList.Add(row);
        }

        /* 
            In a more complex system, titles would be localized 
            and most likley not set directly in code like this.
            Again, this is for the simplicity of this example.
        */
        private string GetRowTitleByAnimalType(AnimalType type)
        {
            switch (type)
            {
                case AnimalType.Dog:
                    {
                        return "Dogs";
                    }
                case AnimalType.Cat:
                    {
                        return "Cats";
                    }
                case AnimalType.Lizard:
                    {
                        return "Lizards";
                    }
                default:
                    // Default text.
                    return "[Missing Name]";
            }
        }

        public void Shutdown()
        {
            // Clean up the row prefabs and their contents
            foreach (AnimalRow row in animalRowList)
            {
                row.Shutdown();
            }
            animalRowList.Clear();
        }
    }

}