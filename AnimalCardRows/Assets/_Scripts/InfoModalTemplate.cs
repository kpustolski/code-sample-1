using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

        public override void Initialize()
        {
            base.Initialize();
        }

        public void Setup(Animal a)
        {
            animalImage.sprite = a.AniSprite;
            descText.text = a.description;

            Initialize();
        }

        public override void Shutdown()
        {
            base.Shutdown();
        }
    }
}