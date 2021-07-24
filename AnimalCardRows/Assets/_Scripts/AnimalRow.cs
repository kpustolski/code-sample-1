using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CodeSampleOne
{
    public class AnimalRow : MonoBehaviour
    {
        [SerializeField]
        private RectTransform cardParent = default;
        [SerializeField]
        private TextMeshProUGUI titleText = default;

        private List<AnimalCard> animalCardList = new List<AnimalCard>();

        public void Setup(string title)
        {
            titleText.text = title;
        }

        public void CreateAnimalCard()
        {
            AnimalRow card = Instantiate(appMan.AnimalCardPrefab, rowParent);
            card.Setup();
            animalCardList.Add(card);
        }

        public void Shutdown()
        {
            foreach (AnimalRow card in animalCardList)
            {
                card.Shutdown();
            }
            animalCardList.Clear();

            Destroy(gameObject);
        }
    }
}