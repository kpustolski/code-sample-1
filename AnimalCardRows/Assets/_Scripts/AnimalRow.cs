using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace CodeSampleOne
{
    public class AnimalRow : MonoBehaviour
    {
        [SerializeField]
        private RectTransform cardParent = default;
        [SerializeField]
        private TextMeshProUGUI titleText = default;
        [SerializeField]
        private ScrollRect scrollView = default;
        private List<AnimalCard> animalCardList = new List<AnimalCard>();
        private AppManager appMan = default;
        private List<Animal> animalData = new List<Animal>();
        private UnityEngine.UI.Extensions.ScrollConflictManager scrollConflictManager = default;
        private string rowTitle = default;

        public void Setup(string title, List<Animal> aniData, ScrollRect parentScrollRect = null)
        {
            appMan = AppManager.Instance;
            titleText.text = rowTitle = title;
            animalData = aniData;

            // Setup the scroll conflict manager.
            // This helps improve the UX of nested scroll rects.
            scrollConflictManager = scrollView.gameObject.GetComponent<UnityEngine.UI.Extensions.ScrollConflictManager>();
            SetParentScrollRect(parentScrollRect);

            CreateAnimalCards();
        }

        public void CreateAnimalCards()
        {
            foreach (var a in animalData)
            {
                AnimalCard card = Instantiate(appMan.AnimalCardPrefab, cardParent);
                card.Setup(a);
                animalCardList.Add(card);
            }
        }

        private void SetParentScrollRect(ScrollRect parentScrollRect)
        {
            if (parentScrollRect == null)
            {
                Debug.LogError($"AnimalRow.cs SetParentScrollRect() :: parentScrollRect is null on row with title: {rowTitle}.");
                return;
            }

            scrollConflictManager.SetParentScrollRect(parentScrollRect);
        }

        public void Shutdown()
        {
            // Clean up the cards and their contents.
            foreach (AnimalCard card in animalCardList)
            {
                card.Shutdown();
            }
            animalCardList.Clear();

            Destroy(gameObject);
        }
    }
}