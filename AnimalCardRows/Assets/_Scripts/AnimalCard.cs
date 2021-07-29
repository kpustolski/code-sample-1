using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

namespace CodeSampleOne
{
    public class AnimalCard : MonoBehaviour
    {
        [SerializeField]
        private Image cardImage = default;
        [SerializeField]
        private TextMeshProUGUI titleText = default;
        [SerializeField]
        private Button button = default;
        private UnityAction cbOnSelect = default;
        private Animal animalObj = default;

        public void Setup(Animal animal, UnityAction onSelect)
        {
            cbOnSelect = onSelect;
            animalObj = animal;

            titleText.text = animalObj.name;

            if (animalObj.AniSprite != null)
            {
                cardImage.sprite = animalObj.AniSprite;
            }

            button.onClick.AddListener(ShowInfoModal);
        }

        public void ShowInfoModal()
        {
            Modals.CreateInfoModal(animalObj, cbOnSelect);
        }

        public void Shutdown()
        {
            button.onClick.RemoveAllListeners();
            Destroy(gameObject);
        }
    }
}