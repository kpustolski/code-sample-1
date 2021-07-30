using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using DG.Tweening;

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

        // For animation
        private RectTransform rectTransform;
        private Vector3 scalePunch = new Vector3(0.07f, 0.07f, 0.07f);
        private const float scaleDuration = 0.2f;
        private const int vibrato = 10;
        private const float elasticity = 1;


        public void Setup(Animal animal, UnityAction onSelect)
        {
            cbOnSelect = onSelect;
            animalObj = animal;
            rectTransform = this.gameObject.GetComponent<RectTransform>();

            titleText.text = animalObj.name;

            if (animalObj.AniSprite != null)
            {
                cardImage.sprite = animalObj.AniSprite;
            }

            button.onClick.AddListener(ShowInfoModal);
        }

        public void ShowInfoModal()
        {
            // Turn off interaction of the button to prevent double clicks.
            button.interactable = false;
            rectTransform.DOPunchScale(scalePunch, scaleDuration, vibrato, elasticity)
            .OnComplete(() =>
            {
                button.interactable = true;
                Modals.CreateInfoModal(animalObj, cbOnSelect);
            });
        }

        public void Shutdown()
        {
            button.onClick.RemoveAllListeners();
            Destroy(gameObject);
        }
    }
}