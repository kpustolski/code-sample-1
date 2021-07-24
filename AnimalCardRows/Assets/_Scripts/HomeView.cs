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

            titleText.text = "This is a title";
            CreateAnimalRows();
        }

        public void CreateAnimalRows()
        {
            AnimalRow row = Instantiate(appMan.AnimalRowPrefab, rowParent);
            row.Setup(title: "Foo");
            animalRowList.Add(row);
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