using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

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

        public override void Initialize()
        {
            base.Initialize();
        }

        public void Setup(Animal a, UnityAction cbOnSelect)
        {
            animalImage.sprite = a.AniSprite;
            descText.text = a.description;
            titleText.text = a.name;

            if (cbOnSelect != null)
            {
                cbOnSelect();
            }

            Initialize();
        }

        public override void Shutdown()
        {
            base.Shutdown();
        }
    }
}