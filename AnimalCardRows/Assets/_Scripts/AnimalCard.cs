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
        // Allows us to grab the id of the animal if we need it.
        public string Id { get { return id; } private set { id = value; } }

        public void Setup(Animal a)
        {
            id = a.id;
            titleText.text = a.name;

            if (a.AniSprite != null)
            {
                cardImage.sprite = a.AniSprite;
            }
        }

        public void Shutdown()
        {
            Destroy(gameObject);
        }
    }
}