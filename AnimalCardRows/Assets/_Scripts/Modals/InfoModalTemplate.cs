using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using DG.Tweening;

namespace CodeSampleOne
{
    public class InfoModalTemplate : ModalBase
    {
        [Header("InfoModalTemple Variables")]
        [Space(5)]
        [SerializeField]
        private Image animalImage = default;
        [SerializeField]
        private TextMeshProUGUI descText = default;
        [SerializeField]
        private TextMeshProUGUI titleText = default;

        [Header("Canvas Groups")]
        [Space(5)]
        [SerializeField]
        private CanvasGroup overlayCanvasGroup = default;
        [SerializeField]
        private CanvasGroup contentPanelCanvasGroup = default;
        [SerializeField]
        private CanvasGroup buttonCanvasGroup = default;

        // Animation variables
        private const float overlayFadeDuration = 0.2f;
        private const float contentFadeDuration = 0.2f;
        private const float buttonFadeDuration = 0.2f;
        private Vector3 contentScalePunch = new Vector3(0.1f, 0.1f, 0.1f);
        private const float contentScaleDuration = 0.2f;

        public override void Initialize()
        {
            base.Initialize();
        }

        public void Setup(Animal a, UnityAction cbOnSelect)
        {
            overlayCanvasGroup.alpha = 0;
            contentPanelCanvasGroup.alpha = 0;
            buttonCanvasGroup.alpha = 0;
            RectTransform contentRectTransform = contentPanelCanvasGroup.gameObject.GetComponent<RectTransform>();

            Sequence showSequence = DOTween.Sequence();
            showSequence.AppendCallback(() =>
            {
                animalImage.sprite = a.AniSprite;
                descText.text = a.description;
                titleText.text = a.name;

                if (cbOnSelect != null)
                {
                    cbOnSelect();
                }

                Initialize();
            })
            .Append(overlayCanvasGroup.DOFade(1f, overlayFadeDuration))
            .Append(contentPanelCanvasGroup.DOFade(1f, contentFadeDuration))
            .Join(contentRectTransform.DOPunchScale(contentScalePunch, contentScaleDuration))
            .Append(buttonCanvasGroup.DOFade(1f, buttonFadeDuration));
        }

        public override void Shutdown()
        {
            // Prevent double clicks by turning off interactivity of the button.
            cancelButton.interactable = false;
            Sequence hideSequence = DOTween.Sequence();
            hideSequence.Append(buttonCanvasGroup.DOFade(0f, buttonFadeDuration))
                .Append(contentPanelCanvasGroup.DOFade(0f, contentFadeDuration))
                .Append(overlayCanvasGroup.DOFade(0f, overlayFadeDuration))
                .OnComplete(() =>
                {
                    base.Shutdown();
                    Destroy(gameObject);
                });
        }
    }
}