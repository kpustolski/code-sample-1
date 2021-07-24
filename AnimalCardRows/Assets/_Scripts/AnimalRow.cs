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
        private AppManager appMan = default;

        public void Setup(string title)
        {
            appMan = AppManager.Instance;
            titleText.text = title;
        }

        public void CreateAnimalCard()
        {
            AnimalCard card = Instantiate(appMan.AnimalCardPrefab, cardParent);
            card.Setup();
            animalCardList.Add(card);
        }

        public void Shutdown()
        {
            foreach (AnimalCard card in animalCardList)
            {
                card.Shutdown();
            }
            animalCardList.Clear();

            Destroy(gameObject);
        }
    }
}