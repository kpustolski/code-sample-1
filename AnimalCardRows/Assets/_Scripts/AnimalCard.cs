using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CodeSampleOne
{
    public class AnimalCard : MonoBehaviour
    {
        [SerializeField]
        private Image cardImage = default;
        [SerializeField]
        private TextMeshProUGUI titleText = default;
        private string id = default;

        public void Setup(Animal a)
        {
            id = a.id;
            titleText.text = a.name;
            cardImage.sprite = a.AniSprite;
        }

        public void Shutdown()
        {
            Destroy(gameObject);
        }
    }
}