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
        private List<Animal> animalData = new List<Animal>();

        public void Setup(string title, List<Animal> aniData)
        {
            appMan = AppManager.Instance;
            titleText.text = title;
            animalData = aniData;

            CreateAnimalCards();
        }

        public void CreateAnimalCards()
        {
            foreach (var a in animalData)
            {
                AnimalCard card = Instantiate(appMan.AnimalCardPrefab, cardParent);
                card.Setup(id: a.id, name: a.name);
                animalCardList.Add(card);
            }
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