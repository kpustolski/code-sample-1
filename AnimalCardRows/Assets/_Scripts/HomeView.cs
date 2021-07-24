using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CodeSampleOne
{
    public class HomeView : MonoBehaviour
    {
        [SerializeField]
        private RectTransform rowParent = default;
        [SerializeField]
        private TextMeshProUGUI titleText = default;

        private List<AnimalRow> animalRowList = new List<AnimalRow>();
        private AppManager appMan = default;

        public void Setup()
        {
            appMan = AppManager.Instance;

            titleText.text = "This is a title for the view";

            foreach (var ani in appMan.sortedAnimalRowData)
            {
                CreateAnimalRows(type: ani.Key, animalData: ani.Value);
            }
        }

        public void CreateAnimalRows(AnimalType type, List<Animal> animalData)
        {
            string rowTitle = GetRowTitleByAnimalType(type: type);
            AnimalRow row = Instantiate(appMan.AnimalRowPrefab, rowParent);
            row.Setup(title: rowTitle, animalData: animalData);
            animalRowList.Add(row);
        }

        public string GetRowTitleByAnimalType(AnimalType type)
        {
            switch (type)
            {
                case AnimalType.Dog:
                    {
                        return "Dog row";
                    }
                case AnimalType.Cat:
                    {
                        return "Cat Row";
                    }
                case AnimalType.Lizard:
                    {
                        return "Lizard Row";
                    }
                default:
                    return "Missing Name";
            }
        }

        public void Shutdown()
        {
            foreach (AnimalRow row in animalRowList)
            {
                row.Shutdown();
            }
            animalRowList.Clear();
        }
    }

}